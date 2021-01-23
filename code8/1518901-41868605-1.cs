    public class ItemObjective : Objective
    {
        public Item RequiredItem { get; private set; }
        override public void CheckIfDone()
        {
            this.IsObjectiveDone = Player.GetInstance().Inventory.Contains(RequiredItem);
        }
    }
