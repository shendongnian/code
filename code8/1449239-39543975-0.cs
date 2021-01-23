    public partial class Form1 : Form
    {
       static Int32 sec = 0;
       static Int32 minut = 0;
       string m;
       string s;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
             m = textBox1.Text.Substring(0, 2);
            s = textBox1.Text.Substring(3, 2);
            sec = Convert.ToInt32(s);
            
            minut = Convert.ToInt32(m);
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
            if(sec>59)
            {
                sec = 1;
                minut++;
            }
            if(minut>59)
            {
                minut = 0;
            }
            label1.Text = minut.ToString() + ":" + sec.ToString();
            //second = second + 1;
            //if (second >= 10)
            //{
            //    timer1.Stop();
            //    MessageBox.Show("Exiting from Timer....");
            //}
        }
        
    }
}
