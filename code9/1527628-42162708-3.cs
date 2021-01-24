    public class Engine : Entity<int>
    {
        public Engine()
        {
            Cars = new List<Car>();
        }
        public virtual int Id { get; protected set; }
        public virtual decimal Displacement { get; set; }
        //more properties
        public virtual IList<Car> Cars { get; }
        public virtual void AddCar(Car car)
        {
            if (Cars.Contains(car)) return;
            Cars.Add(car);
        }
        public virtual void RemoveCar(Car car)
        {
            if (!Cars.Contains(car)) return;
            Cars.Remove(car);
        }
    }
    public class Car : Entity<int>
    {
        public virtual int Id { get; set; }
        public virtual Engine Engine { get; set; }
    }
