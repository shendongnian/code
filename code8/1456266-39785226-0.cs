    public override string ToString()
    {
        return string.Format("{0} {1}", FirstName, LastName);
    }
    public string ToString(string header)
    {
    	return string.Format(header + " - {0} {1}", FirstName, LastName);
    }
