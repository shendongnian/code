    //Pernix Buttons
    private void Pernix1_MouseDown(object sender, MouseEventArgs e)
    {
        int sizePerClick = 80;
        if (e.Button == MouseButtons.Left)
        {
            CountP+=sizePerClick;
            PernixL1.Text = CountP.ToString();
        }
        else if(e.Button==MouseButtons.Right)
        {
            if (CountP > 0)
                CountP-=sizePerClick;
            PernixL1.Text = CountP.ToString();
        }
    
    }
