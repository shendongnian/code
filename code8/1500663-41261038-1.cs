        for (int i = 1; i <= 9999; i++)
        {
            System.Windows.Forms.Application.DoEvents();
            // do something
            label1.Content = 100 * i / 9999 + "%";
            Thread.Sleep(10);
        }
