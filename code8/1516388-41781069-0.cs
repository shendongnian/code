    public string ImageBase64
    {
        get
        {
            
            return this.ImageData != null ? Convert.ToBase64String(this.ImageData) : null;
        }
    }
