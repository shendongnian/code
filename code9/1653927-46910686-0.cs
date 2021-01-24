    [HttpPost("[action]")]
    public void Save([FromBody] List<Models.LinePresentation> lines)
    {
        Save(lines.Select(l=>new Line {LineId = l.LineId, Name = l.Name, LineReferenceId = l.LineReferenceId}))
    }
    
    private void Save(IEnumerable<Line> lines)
    {
        // Most of your code goes here slightly modified to work with business objects
    }
