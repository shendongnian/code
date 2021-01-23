    DateTime dt = new DateTime();
    if(DateTime.TryParse(row.Cells["Day_In"].Value, out dt))
    {
    numDay_In.Text = dt.Day.ToString();
    }
    else
    {
    //Code to display error message
    }
