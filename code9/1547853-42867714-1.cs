    var container = new ChestContainer(240);
    
    for (int i = 0; i < 1000; i++)
        container.Add(new Chest(i, $"{i}"));
**Edit** In order to have the Get method working as well, modifying it as mentioned below will ensure your container works as expected:
    public Chest Get(int index)
    {
        return ChestList[index%(ChestList.Length)];
    }
