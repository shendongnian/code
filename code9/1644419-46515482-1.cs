    private void _btnOK_Click(object sender, EventArgs e)
    {
        _label1.Hide();
        _label2.Hide();
        _label3.Hide();
        Task.Factory.StartNew(() => 
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(5);
                Invoke((Action)(() =>
                {
                    _circularprogressbar.Value = i;
                    _circularprogressbar.Update();
                }));
            }
        });
    }
    
