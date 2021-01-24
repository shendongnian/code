    private void button2_Click(object sender, EventArgs e)
    {
        if (chbRepeat.Checked)
        {
            this.timer2.Start();
        }
        else
        {
            this.timer2.Stop();
            this.SendMail();
        }
    }
    private void timer2_Tick(object sender, EventArgs e)
    {
        this.SendMail();
    }
    private void SendMail()
    {
        MailHelper zmienna = new MailHelper();
        zmienna.wyslijMaila(tbAdresat.Text, tbTemat.Text, tbTresc.Text);
    }
