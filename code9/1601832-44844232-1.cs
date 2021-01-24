    public IHero LevelUp()
    {
		return new Warlock(this.Name, this.Level + 1, this.MagicType);
    }
	
