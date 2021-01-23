    DateTime now = DateTime.Now;
    DateTime newYear = new DateTime(2016, 1, 1);
    // or DateTime newYear = DateTime.Parse("01/01/2016");
    if (newYear.Date == now.Date){
      message.Text = "This is new years";
    }
