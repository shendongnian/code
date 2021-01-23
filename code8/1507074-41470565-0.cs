    _calibrações = new[]
    {
        Properties.Settings.Default.CalibXEsq ?? new TransformaçãoLinear(),
        Properties.Settings.Default.CalibYEsq ?? new TransformaçãoLinear(),
        Properties.Settings.Default.CalibXDir ?? new TransformaçãoLinear(),
        Properties.Settings.Default.CalibYDir ?? new TransformaçãoLinear(),
    };
