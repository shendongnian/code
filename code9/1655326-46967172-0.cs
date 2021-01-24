    /*First Time*/
    double pengar = double.Parse(tbxPengar.Text);
    //tbxPengar.Text = "2000"
    //pengar = 2000
    double satsning = double.Parse(tbxSatsa.Text);
    //tbxSatsa.Text = "100"
    //satsning = 100
    double vinst = satsning * 5;
    //vinst = 100 * 5 = 500
    double total = pengar - satsning + vinst;
    //total = 2000 - 100 + 500 = 2400
    lblPengar.Text = total.ToString();
    //lblPengar.Text = "2400"
