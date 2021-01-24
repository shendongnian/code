    public string Name;
    public MissionHolder missionHolder;
    
    Dictionary<string, Action> animalToAction = new Dictionary<string, Action>();
    
    void Start()
    {
        //Register and animal type and Action
        animalToAction.Add("Tiger", delegate { missionHolder.Tiger += 1; });
        animalToAction.Add("Hyena", delegate { missionHolder.Hyena += 1; });
        animalToAction.Add("Gorilla", delegate { missionHolder.Gorilla += 1; });
        animalToAction.Add("Giraffe", delegate { missionHolder.Giraffe += 1; });
        animalToAction.Add("Gazelle", delegate { missionHolder.Gazelle += 1; });
    }
