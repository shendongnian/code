    private void btnProceed_Click(object sender, EventArgs e)
    {
        string name = tbName.ToString();
        string email = tbEmail.ToString();
        string phone = tbPhone.ToString();
        string color = tbColor.ToString();
        string a = " "+name+" "+email+" "+phone+" "+color;
         backgroundWorker1.RunWorkAsync(a);//passing the variables to the backgroundWorker
    }
