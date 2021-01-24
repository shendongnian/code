    private void btnPrepare_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < 8; i++)
        {
           labels[i].BackColor = System.Drawing.Color.Red;
           labels[i].Update();
           System.Threading.Thread.Sleep(2000);
        }
    }
