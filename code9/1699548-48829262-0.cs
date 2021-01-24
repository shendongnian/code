    private void Form_Load(object sender, EventArgs e)
    {
         string[] q = Enumerable.Range(0, 200).Select(x => $"{(x % 4) + 1} quarter {2012 + x / 4} y.").ToArray();
         Array.Reverse(q);
         domainUpDown1.Items.Clear();
         domainUpDown1.Items.AddRange(q);
         string currentDateTime = GetQuarter(DateTime.Now) + " quarter " + Convert.ToDateTime(DateTime.Now).ToString("yyyy") + " y.";
         domainUpDown1.SelectedItem = currentDateTime;
    }
    public int GetQuarter(DateTime date)
    {
        if (date.Month >= 1 && date.Month <= 3)
           return 1;
        else if (date.Month >= 4 && date.Month <= 6)
           return 2;
        else if (date.Month >= 7 && date.Month <= 9)
           return 3;
        else
           return 4;
    }
