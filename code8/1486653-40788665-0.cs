    bool InFocus = false;
        private void Form1_Load(object sender, EventArgs e)
                {
                    this.KeyPreview = true;
                    this.KeyUp += new System.Windows.Forms.KeyEventHandler(KeyEvent);
                }        
        private void KeyEvent(object sender, KeyEventArgs e)
                {
               if(InFocus ) return;
                    if (e.KeyCode == Keys.Enter)
                    {
                        dataGridViewSkladovePolozky.Focus();
                        pridatDoKosiku();
                    }
                }
        private void buttonPridatDoKosiku_Click(object sender, EventArgs e)
                {
                    pridatDoKosiku();
                }
        private void pridatDoKosiku()
                {
                    PridatDoKosiku pridatDoKosiku = new PridatDoKosiku(); 
    InFocus = true;
                    pridatDoKosiku.ShowDialog();
                    refreshNakupniKosik(true);
                    pridatDoKosiku.Dispose();
    InFocus = false;
                }
