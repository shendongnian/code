    private void _btnOK_Click(object sender, EventArgs e)
        {
            _label1.Hide();
            _label2.Hide();
            _label3.Hide();
    
            for(int i = 1; i <= 100; i++)
            {
                Thread.Sleep(5);
                _circularprogressbar.Value = i;
                _percent_lable_name.Text = string.Format("{0}%", _circularprogressbar.Value);
                _circularprogressbar.Update();
            }
        }
    
        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            _circularprogressbar.Value = 0;
            _circularprogressbar.Minimum = 0;
            _circularprogressbar.Maximum = 100;
        }
    }
