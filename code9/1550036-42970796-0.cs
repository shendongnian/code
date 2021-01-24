    public car save_car(car data)
    {
        if (data.id_car == 0)
        {                
            _contextDrag.car.Add(data);
            _contextDrag.SaveChanges();
            _contextDrag.Entry(data).State = System.Data.Entity.EntityState.Detached;
        }
        else
        {
           _contextDrag.SaveChanges();
        }
            
        return dades;
    }
    public car get_car(long id_car)
    {            
       car data = _contextDrag.car.FirstOrDefault(a => a.idCar == id_car);            
       return data;
    }
