    do
    {
        testing = 0; // now you can start the inner loop with a fresh sounting variable
        do
        {
            Thread.Sleep(1000);
            browser.WaitForComplete(40);
            SendKeys.Send("{END}");
            testing = testing + testing;
            MessageBox.Show("Test with Scroll" + testing.ToString());
        }
        while (testing >= counter);
