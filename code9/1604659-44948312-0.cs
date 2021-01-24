    public class Owner : Entity<Owner>
    {
      ...
    }
    public class Car : Entity<Car>
    {
      ...
    }
    public abstract class Entity<T> : IEntity
      where T: IEntity
    {
      public long Id { get; }
      public static Repository<Entity<T>> CurrentRepository { get; set; }
      static Entity()
      {
        CurrentRepository = new Repository<Entity<T>>();
      }
      public Entity()
      {      
      }
      public void Save()
      {      
        CurrentRepository.Save(this);
      }
      public void Delete()
      {      
        CurrentRepository.Delete(this);
      }    
    }
