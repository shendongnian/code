    public void Kill()
    {
        //If the name exists in the dictionary, execute the corresponding delegate
        Action action;
    
        if (animalToAction.TryGetValue(Name, out action))
        {
            //Execute the approprite code
            action();
        }
    }
