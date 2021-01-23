    IEnumerable<IAnimal> animalList = new List<IAnimal>();
                foreach (IAnimal a in animalList)
                {
                    a.PutInCage();
    
                    //if it's a monkey get its height
                    if (a is Monkey)
                    {
                        var monkey = (Monkey)a; //cast is safe here because you ensure it's a money in the if statement.
                        Show(monkey.Height);
                    }
                    else
                    {
                        //try to get it as an elephant 
                        var elephant = a as Elephant;
                        if (elephant != null)
                            Show(elephant.Weight);
                    }
                }
