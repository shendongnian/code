    public int CompareTo(object obj)
    {
        // Check null
        if (obj == null)
            return 1;
        // Check types
        if (this.GetType() != obj.GetType())
            throw new ArgumentException("Cannot compare to different type.", "obj");
        // Extract year and month
        var year = int.Parse(this.Year.SubString(3, 4));
        var month = int.Parse(this.Year.SubString(0, 2));
        // Extract year and month to compare
        var site = (Sites)obj;
        var objyear = int.Parse(site.Year.SubString(3, 4));
        var objmonth = int.Parse(site.Year.SubString(0, 2));
        // Compare years first
        if (year != objyear)
            return year - objyear;
        // Same year
        // Compare months
        return month - objmonth;
    }
