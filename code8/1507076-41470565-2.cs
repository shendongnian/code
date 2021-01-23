    var settings = Properties.Settings.Default;
    _calibrações = new[]
    {
        settings.CalibXEsq ?? new TransformaçãoLinear(),
        settings.CalibYEsq ?? new TransformaçãoLinear(),
        settings.CalibXDir ?? new TransformaçãoLinear(),
        settings.CalibYDir ?? new TransformaçãoLinear(),
    };
