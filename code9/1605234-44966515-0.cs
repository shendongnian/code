    public void Insert(Entity e)
    {
        if (e is Person)
        {
            Person tmp = e as Person;
            //do your code
        }
        else if (e is City)
        {
            City tmp = e as City;
            //do your code
        }
        else if(e is District)
        {
            District tmp = e as District;
            //do your code
        }
    }
