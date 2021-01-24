    public void WijzigenKlantGegevens(string voornaam, string achternaam, string postcode, string straatnaam, int huisnummer, string woonplaats, string IBAN)
    {
        tbVoornaam.Text = voornaam;
        tbAchternaam.Text = achternaam;
        tbPostcode.Text = postcode;
        tbStraatnaam.Text = straatnaam;
        tbHuisnummer.Text = huisnummer.ToString();
        tbwoonplaats.Text = woonplaats;
        tbIBAN.Text = IBAN;
        this.Show();
    }
