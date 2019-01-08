using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using AutoUpdaterDotNET;
using System.Text.RegularExpressions;

using Methods;
using PhysicsSimulator.Properties;
using System.Reflection;
using System.Threading.Tasks;

namespace PhysicsSimulator
{
    public partial class MainForm : Form
    {

        public const string  ProgrammName = "PhysicMaster";

        public string Manifest = (Environment.CurrentDirectory + @"\Methods\Methods.dll");

        List<Methods.Methods> methods = new List<Methods.Methods>();

        
        
        Font fony = new Font("Franklin Gothic Medium", 10f);

        public MainForm()
        {
            InitializeComponent();
            this.Icon = (Icon)Resources.ResourceManager.GetObject("main_icon");
            flowLayoutPanel1.AutoScroll = true;
            this.MaximizeBox = false;
        
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            

            this.Load += new EventHandler(File_Load);

        }

       

        private async void  File_Load(object sender, EventArgs e)
        {
            if (Settings.Default.MethodsDir == "") Settings.Default.MethodsDir = Environment.CurrentDirectory + @"\Methods\";
            if (!Directory.Exists(Settings.Default.MethodsDir)) Directory.CreateDirectory(Settings.Default.MethodsDir);
            if (!File.Exists(Manifest))
            {
                File.Copy(Environment.CurrentDirectory + @"\Methods.dll",Manifest);
                Application.Restart();
            }

            

            if (Settings.Default.FirstRun == true) FirstRun();
            
            if (Settings.Default.Download)
            {
                Settings.Default.Download = false;
                Settings.Default.Save();
                DownloadMethods();
            }
            if (Settings.Default.Deleted != "" && Settings.Default.Deleted != null)
            {
                File.Delete(Settings.Default.Deleted);
                Settings.Default.Deleted = null;
                Settings.Default.Save();
                
            }
            await Loading();
        }

        private Task Loading()
        {
           return Task.Run(() => {
               

               foreach (var item in (new DirectoryInfo(Settings.Default.MethodsDir).GetFiles()))
                {

                    if (new Regex(@"Methods\.dll$").IsMatch(item.FullName)) continue;

                   Regex reg = new Regex(@"\.dll$", RegexOptions.IgnoreCase);


                    //CreateBox(Methods.GetInfo((await Import(item.FullName)).GetType())[0], "", Color.FromArgb(255, 100, 100, 100));
                    string a = item.FullName;

                   List<Methods.Methods> _set = Methods.Methods.Import(a);
                   
                   if (_set.Count > 0)
                   {
                       foreach (var itm in _set)
                       {
                           
                           if (itm != null)
                           {

                               methods.Add(itm);
                           }
                       }
                   }
                   
                }

                foreach (var item in methods)
                {
                   CreateBox(Methods.Methods.GetInfo(item.type)[0], item, Color.FromArgb(255, 100, 100, 100));
                }

            });
            
        }


        
        private void FirstRun()
        {
            MessageBox.Show("Добро пожаловать в программу " + ProgrammName + "\n Мы видим вы сдесь впервые.\n Сейчас пройдет небольшая настройка." );
            Settings.Default.MethodsDir = Path.Combine(Environment.CurrentDirectory, "Methods");
            if (!Directory.Exists(Settings.Default.MethodsDir)) Directory.CreateDirectory(Settings.Default.MethodsDir);
            DialogResult result = MessageBox.Show("Вы желаете сразу загрузить методы?","Загркзка методов", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                DownloadMethods();
            }
            Settings.Default.BiblName = Environment.CurrentDirectory + @"\Methods.dll";
            MessageBox.Show("Всё настройка завершена, можете приступать к работе.", "Настройка завершена");
            Settings.Default.FirstRun = false;
            Settings.Default.Save();
        }

        private void DownloadMethods()
        {
            var ofd = new OpenFileDialog();
            ofd.AddExtension = true;
            ofd.Multiselect = true;

            ofd.Filter = @"Файлы методов (*.dll)|*.dll";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    if (File.Exists(Settings.Default.MethodsDir + @"\" + ofd.SafeFileNames[i])) File.Delete(Settings.Default.MethodsDir + @"\" + ofd.SafeFileNames[i]);
                        
                    
                    File.Copy(ofd.FileNames[i], Settings.Default.MethodsDir + @"\" + ofd.SafeFileNames[i]);
                    
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        public void CreateBox(string text, Methods.Methods id, Color col)
        {
            var butt = new Button();
            butt.Text = "Выбрать";
            var Name = new Label();
            Name.Text = text;

            ContextMenuStrip cms = new ContextMenuStrip();
            ToolStripItem inf = cms.Items.Add("Информация");
            ToolStripItem del = cms.Items.Add("Удалить");


            inf.Click += new EventHandler(info);
            del.Click += new EventHandler(deleted);

            var panel = new Panel();
            panel.Width = 100;
            panel.Height = 100;
            butt.Parent = panel;
            Name.Parent = panel;
            panel.Tag = id;
            Name.MaximumSize = new Size(100,100);
            Name.MinimumSize = new Size(100, 100);
            Name.Font = fony;
            Name.TextAlign = ContentAlignment.TopCenter;
            Name.ForeColor = SystemColors.HighlightText;


            butt.Click += new EventHandler(click);
            butt.Location = new Point(3,53);
            butt.Dock = DockStyle.Bottom;
            
            panel.BackColor = col;
            butt.BackColor = SystemColors.Control;
            panel.ContextMenuStrip = cms;
            //panel.Parent = flowLayoutPanel1;
            flowLayoutPanel1.Invoke(new Action<Panel>((arr) => arr.Parent = flowLayoutPanel1),panel);
        }

        private void click(object sender, EventArgs e)
        {
            Methods.Methods method = (Methods.Methods)((Button)sender).Parent.Tag;

            this.Hide();
            SimulatedForm sim = new SimulatedForm(method);
            sim.Show();
            sim.FormClosed += new FormClosedEventHandler(simExit);
        }

        private void simExit(object sender, EventArgs e)
        {
            Form sim = (Form)sender;
            sim.Dispose();
            this.Show();
        }

        private void info(object sender, EventArgs e)
        {
            
            var item = (ToolStripItem)sender;
            string outtext = "";
            ContextMenuStrip tools = (ContextMenuStrip)item.Owner;
            var panel = tools.SourceControl;
            
            outtext = outtext + ((Methods.Methods)panel.Tag).Author;
            
            MessageBox.Show(outtext);
        }

        private void deleted(object sender, EventArgs e)
        {
            var item = (ToolStripItem)sender;
            ContextMenuStrip tools = (ContextMenuStrip)item.Owner;
            var panel = tools.SourceControl;
            if(MessageBox.Show("Вы действитльно хотите удалить этот файл?","Удаление файла",MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk) == DialogResult.OK)
                Delete(((Methods.Methods)panel.Tag).Pach);
        }

        private void Delete(string pach)
        {
            
            if (File.Exists(pach) && pach.IndexOfAny(Path.GetInvalidPathChars()) == -1)
            {
                Settings.Default.Deleted = pach;
                Settings.Default.Save();
                Application.Restart();
            }
            else MessageBox.Show("Нет файла");
        }

        

        

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void сброситьВсеНастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.FirstRun = true;
            Settings.Default.Save();
            
        }

        private void загрузитьМетодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Приложение будет перезапущенно! \n Вы согласны?","Внимание",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Settings.Default.Download = true;
                Settings.Default.Save();
                Application.Restart();
            }
           
        }

        private void setting_Click(object sender, EventArgs e)
        {
            SettingsForm sett = new SettingsForm();

            sett.ShowDialog();
        }
    }

}
