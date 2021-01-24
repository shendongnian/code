    class Download
    {
       ...
       public string Link {get;set;}
    }
    class ParentClass
    {
       ...
       public virtual ICollection<Download> Links {get;set;}
    }
