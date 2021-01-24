    private void btnPrepare_Click(object sender, EventArgs e)
    {
        Application.DoEvents();
        for (int i = 0; i < 8; i++)
        {
           labels[i].BackColor = System.Drawing.Color.Red;
           Application.DoEvents();
           System.Threading.Thread.Sleep(2000);
        }
    }
