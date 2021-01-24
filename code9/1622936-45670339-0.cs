    class Methods<T> where T : class, ITexted
    { 
        bool insertDocument(T content)
        {
            return client.search(content.Text);
        }
    }
    public interface ITexted
    {
        string Text {get; set;}
    }
    
    class UsedClass : ITexted
    {
       public string Text { get; set; }
    }
