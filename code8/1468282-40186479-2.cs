    using System;
    using System.Windows.Forms;
    using System.Windows.Threading;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.Load += Form1_Load;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                UpdateGuiItems();
            }
    
            private void UpdateGuiItems()
            {
                var timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(5);
                timer.Tick += OnUpdateGuiItemsTimerTick;
                timer.Start();
            }
    
            private void OnUpdateGuiItemsTimerTick(object sender, EventArgs e)
            {
                var timer = sender as DispatcherTimer;
                timer.Stop();
    
                MessageBox.Show("Am I on the UI thread: " + !this.InvokeRequired);
            }
        }
    }
