    string t = "";
    foreach (char c in Properties.Settings.Default.password)
    {
          if (IsNumber(x)) t += System.Convert.ToInt32(c).ToString();
          else
          {
              t += c.ToString();
          }
    }
