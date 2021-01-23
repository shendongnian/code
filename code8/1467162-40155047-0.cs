    public void AddSpans()
    {
      textBox1.Text = "12:31";
      textBox2.Text = "13:40";
      string[] splitArray1 = textBox1.Text.ToString().Split(':');
      string[] splitArray2 = textBox2.Text.ToString().Split(':');
      int hr1, hr2, m1, m2;
      if ((int.TryParse(splitArray1[0], out hr1)) &&
           (int.TryParse(splitArray1[1], out m1)) &&
           (int.TryParse(splitArray2[0], out hr2)) &&
           (int.TryParse(splitArray2[1], out m2)))
      {
        TimeSpan ts1 = new TimeSpan(hr1, m1, 0);
        TimeSpan ts2 = new TimeSpan(hr2, m2, 0);
        TimeSpan ts3 = ts1.Add(ts2);
        int totHrsFromDays = ts3.Days * 24;
        textBox3.Text = (totHrsFromDays + ts3.Hours) + ":" + ts3.Minutes;
      }
      else
      {
        // invalid format HH:MM
      }
