    public bool IsResponsiblePerson 
    { 
        get 
        { 
            return this.Name == ResponsiblePerson; 
        }
        set 
        {   
            if (value)
            {
                 ResponsiblePerson = this.Name;
            }
            else
            {
                if (this.Name == ResponsiblePerson)
                {
                    ResponsiblePerson = "";
                }
            }
        }
    }
