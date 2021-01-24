    public class ItemCombination
    {
        public ItemCombination(string Item1, string Item2, Action interaction)
        {
            this.Item1 = Item1;
            this.Item2 = Item2;
            this.interaction = interaction;
        }
    
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public Action Interaction { get; set; }
    
        public void Interact()
        {
           // safeguard against null delegate
           Interaction?.Invoke();
        }
    }
