    private void wylicz_Click(object sender, RoutedEventArgs e)
    {
        string a, b, c;
    
        var culture = System.Globalization.CultureInfo.CreateSpecificCulture("pl-PL");
        var style = System.Globalization.NumberStyles.Number;
        a = wpis_a.Text;
        b = wpis_b.Text;
        c = wpis_c.Text;
    
        double liczba1 = 0.0;
        double liczba2 = 0.0;
        double liczba3 = 0.0;
    
        if (!(double.TryParse(a, style, culture, out liczba1) && double.TryParse(b, style, culture, out liczba2) && double.TryParse(c, style, culture, out liczba3)))
        {
            trzyde_wynik.Text = "bad values";
        }
        else
        {
            double trzyde_w = (liczba1 * liczba2 * liczba3) / 1000000;
            trzyde_wynik.Text = trzyde_w.ToString("F6", culture);
        }
    }
