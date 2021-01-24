    public Hero GetSelected()
    {
        return selectedHero;
    }
    
    public void SetSelected(Hero h)
    {
        selectedHero = h;
    }
    
    public bool HasSelected()
    {
        return !(selectedHero.Equals(default(Hero)));
    }
    
    public void ClearSelected()
    {
        selectedHero = default(Hero);
    }
