    private void Sub_Click(object sender, RoutedEventArgs e)
    {
        customer newCus = new customer();
        account newAcc= new account();
        try
        {
            newCus.NAME = Nameadd.Text;
            newCus.pin = pinadd.Text;
            newAcc.PIN = pinadd.Text;
            newAcc.accountnumber = Accountnumadd.Text;
            newAcc.accounttype = 'C';
            for (int i = 0; i < acclist.Count; i++) // here you are checking acclist.Count... each iteration this increases by 1, thus i will never technically ever be equivalent to acclist.Count
            {
                {
                    if(newAcc.accounttype == 'C')
                    {
                        newAcc.PIN = pinadd.Text;
                        newAcc.accountnumber = Accountnumadd.Text;
                        newAcc.accounttype = 'S';
                    }
                }
                cuslist.add(newCus);
                acclist.add(newAcc); // <-- this is where you're adding to acclist each time.  However inside this loop you're constantly increasing its size... thus your infinite loop you're hitting.
                savefile();
                saveaccount();
            }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
