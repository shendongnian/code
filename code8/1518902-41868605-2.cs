    public class Quest
    {
        public ObjectiveGroup { get; private set; }
        public Quest(TypeOfQuest aType, Requirements[] aReq)
        {
            this.ObjectiveGroup = ObjectiveGroup.Create(aType, aReq);
        }
    }
    public class Player
    {
        public List<Quest> Quests = new List<Quest>();
        public List<Item> Inventory = new List<Item>();
    }
    public void Main(/* ... */)
    {
        Player player = new Player();
        player.Quests.Add(new Quest(TypeOfQuest.ItemObtain, new Requirements[] { Item["Sword of Conan"] });
        while(true)
        {
            player.Quests.ObjectiveGroup.ForEach(a => a.SubObjectives.ForEach(b => b.CheckIfDone()));
            foreach(var objGrp in player.Quests.ObjectiveGroup)
                if(objGrp.IsObjectiveDone) Console.WriteLine("Quest completed");
        }
    }
