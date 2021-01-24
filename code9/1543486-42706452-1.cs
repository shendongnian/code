    public List<HelpDesk> getOplossing()
    {
        string probleem = getProbleem().ToString();
        return _persistcode.getOplossing(probleem);
    }
