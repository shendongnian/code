    using System.Diagnostics;
    using System.Windows.Forms;
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
    
            var watch = new Stopwatch();
            KeyDown += (s, e) => watch.Start();
            KeyUp += (s, e) => { 
                watch.Stop();
                var elapsed = watch.ElapsedMilliseconds;    // Duration
                watch.Reset();
            };
        }
    }
