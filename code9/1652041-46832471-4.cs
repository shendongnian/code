    public void FeedAnimals(Menagerie x)
    {
        var animals = x.getAnimals()
        foreach (var animal in animals)
        {
            if (animal.Name == "cat")
            {
                FeedTheCat();
            } else if (animal.Name == "dog")
            {
                feedTheDog();
            } else if (animal.Name == "bees")
            {
                PutOnBeeSuit();
                foreach(bee in bees) FeedAnimals(new Menagerie() {bee});
            }
            else
            {
                CallAMeeting();
                FeedAnimals(new Menagerie() {employees});
            }
        }
    }
