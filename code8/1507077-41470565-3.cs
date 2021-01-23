    var settings = Properties.Settings.Default;
    _calibrações = new[]
    {
        settings.CalibXEsq ?? (settings.CalibXEsq = new TransformaçãoLinear()),
        settings.CalibYEsq ?? (settings.CalibYEsq = new TransformaçãoLinear()),
        settings.CalibXDir ?? (settings.CalibXDir = new TransformaçãoLinear()),
        settings.CalibYDir ?? (settings.CalibYDir = new TransformaçãoLinear()),
    };
