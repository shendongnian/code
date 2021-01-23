       double sTime ;              
        var sLines = File.ReadAllLines("//dnc/WaterJet/MTI-WJ/" +   cboPartProgram.Text)
            .Where(s => !s.StartsWith("'") && s.Contains("S"))
            .Select(s => new
            {
                SValue = Regex.Match(s, "(?<=S)[\\d.]*").Value
            })
            .ToArray();
        foreach (var lines in sLines)
        {
            sTime = double.Parse(lines.SValue);
            
        }
