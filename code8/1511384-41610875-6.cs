        using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private readonly TimeSpan _updateInterval = TimeSpan.FromSeconds(1);
            private System.Threading.Timer _timer;
            public Form1()
            {
                InitializeComponent(); this.DoubleBuffered = true;
                _timer = new System.Threading.Timer(timer_Tick, null, _updateInterval, _updateInterval);
    
                NewFile();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
            private void NewFile() { }
            private void timer_Tick(object state)
            {
                MessageBox.Show("TIMER TICKS");
    
                //doc.MoveBalls(leftX, topY, width, height);
                //doc.CheckCollision();
                //Invalidate(true);
    
                Console.WriteLine("Moving2");
            }
        }
    }
