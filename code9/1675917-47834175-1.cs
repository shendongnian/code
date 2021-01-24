    public void Kill()
    {
        //If the name exist in the dictiinray, exceute the corresponding delegate
        Action action;
    
        if (animalToAction.TryGetValue(name, out action))
        {
            //Execute the approprite code
            action();
        }
    }
