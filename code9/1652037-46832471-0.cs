    public void FeedAnimals(Menagerie x, string id = null)
    {
        var elements = xml.Elements().ToList();
        foreach (var element in elements)
        {
            if (element.Name == "cat")
            {
                FeedTheCat();
            } else if (element.Name == "dog")
            {
                feedTheDog();
            } else if (element.Name == "bees")
            {
                PutOnBeeSuit();
                foreach(bee in bees) FeedAnimals(new Menagerie() {bee}, tempId);
            }
            else
            {
                CallAMeeting();
                FeedAnimals(new Menagerie() {employees}, id);
            }
        }
    }
