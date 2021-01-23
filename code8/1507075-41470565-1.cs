    _calibrações = new[]
    {
        Properties.Settings.Default.CalibXEsq ?? (Properties.Settings.Default.CalibXEsq = new TransformaçãoLinear()),
        Properties.Settings.Default.CalibYEsq ?? (Properties.Settings.Default.CalibYEsq = new TransformaçãoLinear()),
        Properties.Settings.Default.CalibXDir ?? (Properties.Settings.Default.CalibXDir = new TransformaçãoLinear()),
        Properties.Settings.Default.CalibYDir ?? (Properties.Settings.Default.CalibYDir = new TransformaçãoLinear()),
    };
