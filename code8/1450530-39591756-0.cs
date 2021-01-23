    DateTime dt = new DateTime();
    if (DateTime.TryParse(c.Text, out dt))
    {
      DateTime now = DateTime.Now;
      if (dt.Date >= now.Date && dt.Date <= now.AddDays(Mod.ValidUntilDays).Date)
      {
         e.Item.Style.Add("background-color", "#FF0303");
      }
    }
