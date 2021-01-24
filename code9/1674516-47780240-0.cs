    [Given("the coordinates are '(.*)'")]
    public void Step(Something something)
    {
        // Does not work (parameter count mismatch)
    }
    
    [StepArgumentTransformation("X:(\d)/Y:(\d)")]
    public Something Transform(int x, int y)
    {
        var something = new Something(x, y);
        return something;
    }
    
    Usage:
    
    Scenario: coordinate system
    
        Given the coordinates are 'X:1/Y:2'
