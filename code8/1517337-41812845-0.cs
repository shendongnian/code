    DateTime cellDate;
    if (DateTime.TryParse(xlRange.Cells[i, j].Value, out cellDate)) {
      Console.WriteLine("Valid Date: " + cellDate.ToLongDateString());
    }
    else {
      Console.WriteLine("Date Is Invalid: " + xlRange.Cells[i, j].Value);
    }
