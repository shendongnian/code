    public static int MyMethod(TextBox t)
    {
        int i = 0;
        for (int j = 1; j <= 20; j++)
        {
            i = j;
            t.Text = j.ToString();
            Application.DoEvents();
            Thread.Sleep(200);
        }
        return i;
    }
