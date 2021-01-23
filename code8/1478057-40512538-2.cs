    public static void GetUserGUIDandSID(string username, object b, object c)
    {
        ...
        foreach (var o in new object[] { b, c })
        {
            if (o is Label)
            {
                ((Label)o).FontSize = 10;
                ((Label)o).Content = empIdNum;
            }
            else if (o is TextBox)
            {
                ((TextBox)o).FontSize = 10;
                ((TextBox)o).Text = empIdNum.ToString();
            }
            else if (o is TextBlock)
            {
                ((TextBlock)o).FontSize = 10;
                ((TextBlock)o).Text = empIdNum.ToString();
            }
        }
    }
