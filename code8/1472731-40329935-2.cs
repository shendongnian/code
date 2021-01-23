    DateTime MyDate = new DateTime(2017, 1, 15);
    DatePickerDialog dialog = new DatePickerDialog(Activity,
                                                   this,
                                                   MyDate.Year,
                                                   MyDate.Month - 1,
                                                   MyDate.Day);
