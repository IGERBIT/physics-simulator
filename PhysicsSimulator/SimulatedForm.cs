using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using PhysicsSimulator.Properties;
using Methods;

namespace PhysicsSimulator
{
    public partial class SimulatedForm : Form
    {
        Methods.Methods method;

        Control panel = new Panel();

        System.Threading.Timer tim;
        System.Threading.Timer Sbros;

        public SimulatedForm(Methods.Methods method)
        {
            this.method = method;
            
            InitializeComponent();
            this.Icon = (Icon)Resources.ResourceManager.GetObject("main_icon");
            this.Load += new EventHandler(LoadInterface);
            this.FormClosed += new FormClosedEventHandler(cls);
            this.MaximizedBoundsChanged += new EventHandler(EndResize);
            this.SizeChanged += new EventHandler(EndResize);
            this.Load += new EventHandler(Form_Load);
            
            
        }

        private void EndResize(object sender, EventArgs e)
        {
            
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Stop();
        }

        private void cls(object sender, FormClosedEventArgs e)
        {
            if (tim == null) return;
            tim.Dispose();
            tim = null;
        }

        private void LoadInterface(object sender, EventArgs e)
        {
            
            panel.Width = inerface.Width;
            panel = method.mInterface(inerface.Width);
            panel.Parent = inerface;
        }

        

#pragma warning disable CS0108 // "SimulatedForm.Resize(object, EventArgs)" скрывает наследуемый член "Control.Resize". Если скрытие было намеренным, используйте ключевое слово new.
        private void Resizeing(object sender, EventArgs e)
#pragma warning restore CS0108 // "SimulatedForm.Resize(object, EventArgs)" скрывает наследуемый член "Control.Resize". Если скрытие было намеренным, используйте ключевое слово new.
        {
            double wight = this.Size.Width - 10;
            
            double height = this.Size.Height - 70;
            
            if (wight > height)
            {
                
                visual.Size = new Size((int)height - 15,(int)height - 15);
                values.Size = new Size((int)wight - (visual.Size.Width + 30), (int)height);
                values.Location = new Point(visual.Location.X + visual.Size.Width + 5,values.Location.Y);

            }
            else
            {
                int size = (int)Math.Round(height * 0.88);
                visual.Size = new Size(size,size);
                
            }


            
        }

        private void  Stop()
        {
            if (tim != null)
                tim.Dispose();
            if(Sbros != null)
                Sbros.Dispose();
            tim = null;
            Sbros = null;
            start.Tag = true;
            start.Invoke(new Action<string>((str) => start.Text = str),"Старт");
            sbros(this);
        }

        private void Start()
        {
            if (tim == null) tim = new System.Threading.Timer(new TimerCallback(Draw), false, 0, method.Period);
            if (Sbros == null) Sbros = new System.Threading.Timer(new TimerCallback(sbros), null, 0, 5000);
            start.Tag = false;
            start.Invoke(new Action<string>((str) => start.Text = str), "Стоп");
        }

        private void sbros(object state)
        {
            GC.GetTotalMemory(true);
        }

        

        private void start_Click(object sender, EventArgs e)
        {
            if ((bool)start.Tag) Start();
            else Stop();
        }

        private  void Draw(object state)
        {   
            Image img = method.mDraw(visual.Height,visual.Width,panel);
            visual.Image = img;
            if (img.Tag != null) { if ((bool)img.Tag) Stop(); }           
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    
}
