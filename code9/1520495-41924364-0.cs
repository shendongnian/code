    private void txtDataNasc_TextChanged(object sender, TextChangedEventArgs e)
    {
        string stg = txtDataNasc.Text;
        if (!string.IsNullOrEmpty(stg))
        {
            stg += " 00:00:00";
            DateTime date = default(DateTime);
            if (DateTime.TryParseExact(stg, "dd-MM-yyyy hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                _student.Student_birthDate = date;
            }
        }
    }
