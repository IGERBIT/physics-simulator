using System;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

namespace Methods
{
    public interface IMethod
    {
        Control SetInterface(int wight);
        Image Draw(int height, int weight,Control panel);
    }

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class MethodInfoAttribute : System.Attribute
    {
        private string methodName;
        public string Name
        {
            get
            {
                return methodName;
            }
            set
            {
                methodName = value;
            }
        }

        private string methodAuthor;
        public string Author
        {
            get
            {
                return methodAuthor;
            }
            set
            {
                methodAuthor = value;
            }
        }

        private int methodFps;
        public int Period
        {
            get
            {
                return methodFps;
            }
            set
            {
                methodFps = Math.Max(value,100);
            }
        }

        public MethodInfoAttribute() { }
    }

    public enum ElementType { Lable, TextBox, CheckBox };

    public class MethodInterface
    {


        static public Control CreateLable(string text)
        {

            Control lable = new Label();
            lable.Text = text;
            lable.AutoSize = true;
            return lable;
           
        }

        static public Control CreateElement(string text, ElementType type, object id)
        {
            Control _out = new FlowLayoutPanel();


            switch (type)
            {
                case ElementType.CheckBox:
                    {
                        FlowLayoutPanel panel = new FlowLayoutPanel();
                        panel.Tag = 2;
                        Label lb = new Label();
                        lb.Tag = id;
                        lb.AutoSize = true;
                        lb.Text = text;
                        lb.Parent = panel;

                        CheckBox cb = new CheckBox();
                        cb.Parent = panel;


                        panel.Parent = _out;

                    }
                    break;
                case ElementType.Lable:
                    {
                        Label lb = new Label();
                        lb.AutoSize = true;
                        lb.Text = text;
                        lb.Tag = -1;
                        lb.Parent = _out;

                    }
                    break;
                case ElementType.TextBox:
                    {
                        FlowLayoutPanel panel = new FlowLayoutPanel();
                        panel.Tag = 1;
                        Label lb = new Label();
                        lb.Tag = id;
                        lb.AutoSize = true;
                        lb.Text = text;
                        lb.Parent = panel;

                        TextBox tb = new TextBox();
                        tb.Parent = panel;

                        panel.Parent = _out;



                    }
                    break;
            }


            return _out;
        }

        static public object GetElement(Control element, object id)
        {
            object _out = null;
            object ch;

            foreach (Control child in element.Controls)
            {
                if ((int)child.Tag > 0 && (int)child.Tag < 3)
                {
                    if ((int)child.Tag == 1)
                    {
                        ch = child.Controls[0].Tag;
                        if (ch != id) continue;
                        return ((TextBox)(child.Controls[1])).Text;
                    }

                    if ((int)child.Tag == 2)
                    {
                        ch = child.Controls[0].Tag;
                        if (ch != id) continue;
                        return ((CheckBox)(child.Controls[1])).Checked;
                    }
                }
            }

            return _out;
        }

        static public int IntParse(string text)
        {
            int _out = 0;
            int.TryParse(text, out _out);
            return _out;

        }

        static public Control  CreateComboBox(string name, object id, params string[] items) // Создание выпадающего списока
        {
            Control panel = new Panel(); // Создаём основную панель выпадающего списка

            Label text = new Label(); // Создаём пустую надпись
            text.AutoSize = true; // Делаем чтоб надпись сама изменяла свой размер в зависимости от текста 
            ComboBox box = new ComboBox(); // создаём сам выпадающий список
            box.DropDownStyle = ComboBoxStyle.DropDownList; // Делаем так чтоб пользователь мог выберать только из предложеных вариантов

            foreach (string item in items) // перебираем значение переданые в массиве items
            {
                box.Items.Add(item); // Добавляем их к выпадающему списку по очереди
            }
            box.SelectedIndex = 0; // Ставим выбраным по умолчаанию первый элемент

            text.Text = name; // Для надписи устанавливаем текст названия списка
            text.Font = new Font("Microsoft Sans Serif", 10); // меняем шрифт

            panel.Height = (new ComboBox()).Height + 5; // Устанавливаем высоту панели
            panel.Width = (name.Length * 9) + 10 + box.Width; // считаем и ставим ширину панели

            box.Tag = id; // устанавливаем id по которому будем отлечать его 


            text.Parent = panel; // Добовляем созданый текст к панели
            box.Parent = panel; // Добовляем созданый выпадающий список к панели

            box.Location = new Point((name.Length * 9), 0); // Сдвигаем выпадающий список ливее текста


            panel.Tag = "CB"; // Делаем пометку что это выпадающий список

            return panel;
        }


        static public string GetComboBox(Control main, object id)
        {

            string _out = "";
            try
            {

                foreach (Control item in main.Controls)
                {
                    if ((string)item.Tag == "CB" && item.Controls[1].Tag == id)
                    {

                        ComboBox cb = (ComboBox)item.Controls[1];

                        return cb.SelectedItem.ToString();
                    }
                }
            }
            catch { }


            return _out;
        }
    }


   public class Methods
   {
        public Type type { get; set; }
        public Func<int,Control> mInterface { get; set; }
        public Func<int,int,Control,Image> mDraw { get; set; }
        public string Pach { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Period { get; set; }

        

        public Methods(Type t,IMethod mt,string pach)
        {
            type = t;
            mInterface = mt.SetInterface;
            mDraw = mt.Draw;
            Pach = pach;
            Name = GetInfo(type)[0];
            Author = GetInfo(type)[1];
            Period = int.Parse(GetInfo(type)[2]);
        }

        static public List<Methods> Import(string pach)
        {

            Assembly asm;
            List<Methods> app = new List<Methods>();




            try
            {
                asm = Assembly.LoadFrom(pach);
                Type[] types = asm.GetTypes();
                foreach (var item in types)
                {
                    Type obg = item.GetInterface("IMethod");
                    if (obg != null)
                    {

                        object o = asm.CreateInstance(item.FullName);


                        app.Add(new Methods(item, o as IMethod, pach));



                    }
                }
            }
            catch (Exception e)
            {

                
                FileInfo file = new FileInfo(pach);



                if (Properties.Settings.Default.NotMethods.IndexOf(file.Name) == -1)
                {
                    DialogResult r = MessageBox.Show("При загрузке метода из файла " + file.Name + " произошла ошибка.\n\n" +
                        "Возможно это не метод, а дополнительный файл.\n" +
                        "Если это так то мы добавим его в список исключений.\n" +
                        "Если вас интересует ошибка которая произошла, нажмите Отмена/Cancel" +
                        "Вы желаете добавить файл в исключения?", "Загрузка файла " + file.Name, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                    if (r == DialogResult.Yes) { Properties.Settings.Default.NotMethods = Properties.Settings.Default.NotMethods + file.Name; Properties.Settings.Default.Save(); }
                    if (r == DialogResult.Cancel) MessageBox.Show("Ошибка в файле " + file.Name + ":\n" + e.Message, "Вызваное исключение");

                    
                }
                return app;
            }

            

            

            return app;



        }

        static public string[] GetInfo(Type m)
        {
            string[] outp = new string[3];

            object[] o = m.GetCustomAttributes(false);

            foreach (MethodInfoAttribute item in o)
            {
                outp[0] = item.Name;
                outp[1] = item.Author;
                outp[2] = item.Period.ToString();
            }

            return outp;
        }

        

        


        

    }
}


