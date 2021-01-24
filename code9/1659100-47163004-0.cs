    namespace Morse_Code
    {
        public partial class frmdecdotmode : Form
        {
            Boolean flag_isdown = false;
            Stopwatch sw = new Stopwatch();
            Timer morse_timer = new Timer();
            string listofcode;
            DataSet datas = new DataSet();
            DataBaseController dbc = new DataBaseController();
            public frmdecdotmode()
            {
                InitializeComponent();
            }
    
            private void frmdecdotmode_FormClosing(object sender, FormClosingEventArgs e)
            {
                MainMenu mm = new MainMenu();
                mm.Show();
                this.Hide();
            }
    
            private void txtletters_KeyDown(object sender, KeyEventArgs e)
            {
                flag_isdown = true;
                txtletters.BackColor = Color.Yellow;
                sw.Start();
                morse_timer.Stop();
            }
    
            private void txtletters_KeyUp(object sender, KeyEventArgs e)
            {
                flag_isdown = false;
                txtletters.BackColor = Color.White;
                sw.Stop();
                if (sw.ElapsedMilliseconds < 250)
                    listofcode += ".";
                else
                    listofcode += "-";
                sw.Reset();
                morse_timer.Start();
            }
    
            private void frmdecdotmode_Load(object sender, EventArgs e)
            {
                morse_timer.Interval = 1000;
                morse_timer.Enabled = true;
                morse_timer.Tick += morse_timer_Tick;
            }
            private void morse_timer_Tick(object sender, EventArgs e)
            {
                if (flag_isdown == false && listofcode != null)
                {
                    datas = dbc.srchfortext(listofcode);
                    lbltext.DataBindings.Clear();
                    lbltext.DataBindings.Add("text", datas, "t.letter");
                    txtletters.Text += lbltext.Text;
                    listofcode = "";
                }
            }
        }
    }
