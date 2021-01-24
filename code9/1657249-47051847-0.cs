    TextFieldParser sprawdz = new TextFieldParser("C:\\wykaz_druk.csv");
    string currentLine;
    string searchcsv = textBox_SPR_SEARCH.Text;
    sprawdz.TextFieldType = FieldType.Delimited;
    sprawdz.Delimiters = new string[] { ";" };
    sprawdz.TrimWhiteSpace = true;
    do
    {
        currentLine = sprawdz.ReadLine();
        if (currentLine != null)
        {
            string file = currentLine;
            string adresip = file.Split(';')[2].Trim();
            if(adresip == searchcsv)
            {
                textBox2.Text = adresip;
            }
        }
    }
    while (currentLine != null);
