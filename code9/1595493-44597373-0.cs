    if (iplist.Any(ip => ip == WebIP))
    {
        MessageBox.Show("Passed");
    }
    else
    {
        this.Close();
    }
