    public interface Eliminatable
    {
        bool Eliminated { get; set; }
    }
    public void Delete<T>(List<T> data) where T : Eliminatable
    {      
        if (data != null)
        {
            data.ForEach(x => { x.Eliminated = true; });
        }           
    }
