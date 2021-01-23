    private void Compare()
    {
        Color cBackColor = Color.Red;
        if (tbRegPersPlacÅrArb.Text == Kvarattfördela.Text)
        {
            cBackColor = Color.Green;
        }
        tbRegPersPlacÅrArb.BackColor = cBackColor;
        Kvarattfördela.BackColor = cBackColor; 
    }
