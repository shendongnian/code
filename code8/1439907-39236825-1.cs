    public foo : IHasCar
    {
        long IdCar { get; set; }
        ICar car { get{ return mainCar; } set{ if(value is Car)mainCar = (Car)value; } }
        Car mainCar{ get; set; }
    }
