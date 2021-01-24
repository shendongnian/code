    public void FeedAnimals(List(of Animal) menagerie, string id = null)
    {
        foreach (var animal in menagerie)
        {
            if (animal is Cat)
            {
              animal.Feed();
            } else if (animal is Dog)
            {
                animal.Feed();
            } else if (animal is Bee)
            {
                PutOnBeeSuit();
                foreach(bee in bees) bee.Feed();
            }
            else
            {
                CallAMeeting();
                animal.feed();
            }
        }
    }
