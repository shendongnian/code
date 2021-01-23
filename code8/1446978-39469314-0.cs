    cmd.Parameters.AddWithValue("@StartDate", ParseDate(TextBoxBeginDatum.Text));
    cmd.Parameters.AddWithValue("@EndDate", ParseDate(TextBoxEindDatum.Text));
    ...
    static DateTime ParseDate(string text) {
        // TODO; possibly just: return DateTime.Parse(text);
    }
