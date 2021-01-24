    [XmlElement("framerate_denominator")]
    public string _FramerateDenominator { get; set; }
    [XmlIgnore]
    public int? FramerateDenominator
        => !string.IsNullOrEmpty(_FramerateDenominator) 
            ? (int?) int.Parse(_FramerateDenominator) 
            : null;
