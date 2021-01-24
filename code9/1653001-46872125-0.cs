    if ( Result == 0)
    {
        MessageBox.Show("It's good")
    }
    else if ( Result == -4)
    {
        Thread.Sleep(20000);
        MyMethod.TryAgain();
    }
    else
    {
        MessageBox.Show("It's bad");
    }
