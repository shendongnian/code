    communications.Select(c => new XElement("node",
        new XAttribute("guid", Guid.NewGuid()),
        new XAttribute("title", BuildTitle(c)),
        new XAttribute("isHidden", false))))
    private string BuildTitle(CommuncationDetails c)
    {
        var culturedDetails = c.CommunicationDetails.Where(x => x.CultureCode == culture).FirstOrDefault();
        
        if (culturedDetails == null || string.IsNullOrEmpty(culturedDetails.Title)) return string.Empty;
    
        return culturedDetails.Title.Substring(0, Math.Min(40, culturedDetails.Title.Length));
    }
