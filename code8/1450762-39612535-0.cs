    int Total;
    List<int> GBTotal = new List<int>()
    foreach(GroupBox gb in Controls.OfType<GroupBox>())
    {
        int temp = 0;
        foreach(TextBox tb in gb.Controls.OfType<TextBox>())
        {
            int A1 = 0;
            if(int.TryParse(tb.Text, out A1))
            {
               temp += A1;
            }
        }
        GBTotal.Add(temp);
    }
    Total = GBTotal.Sum();
