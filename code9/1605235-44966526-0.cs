    public void Insert<T>(T entity) where T: Entity
    {
        if(entity is City)
        {
            City city = (City) entity;
            // ...
        }
        else if(entity is Person)
        {
            Person person = (Person) entity;
            // ...
        }
    }
