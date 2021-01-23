    public interface ICar
    {
        // ICar members
    }
    
    public interface IHasCar<TCar>
           where TCar : class, ICar 
           // TCar must be a class and it must implement ICar
    {
         TCar Car { get; set; }
    }
