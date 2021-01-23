    public bool HasValues
    {
        get
        {
            return !string.IsNullOrWhiteSpace(this.AdsTitle) ||
                   !string.IsNullOrWhiteSpace(this.Description) ||
                   this.ToDateTime.HasValue ||
                   ... etc ...
        }
    }
