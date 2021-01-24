    switch (columnType)
    {
       case int:
          TextBoxInt.Visible = true;
          TextBoxString.Visisble = false;
          DateTimePicker.Visible = false;
          break;
       case string:
          TextBoxString.Visible = true;
          TextBoxInt.Visible = false;
          DateTimePicker.Visible = false;
          break;
       case DateTime:
          DateTimePicker.Visible = true;
          TextBoxInt.Visible = false;
          TextBoxString.Visible = false;
          break;
    }
