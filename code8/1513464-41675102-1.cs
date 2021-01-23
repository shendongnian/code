    public class ChosenItemsContainer : IItemContainer<FabulousItem>, IItemContainer<NiceItem>, IItemContainer<GreedyItem> {
    
        public FabulousItem ChosenFabulousItem { get; set; }
        public NiceItem ChosenNiceItem { get; set; }
        public GreedyItem ChosenGreedyItem { get; set; }
    
        FabulousItem IItemContainer<FabulousItem>.ChosenItem {
            get {
                return ChosenFabulousItem;
            }
            set {
                ChosenFabulousItem = value;
            }
        }
        NiceItem IItemContainer<NiceItem>.ChosenItem {
            get {
                return ChosenNiceItem;
            }
            set {
                ChosenNiceItem = value;
            }
        }
        GreedyItem IItemContainer<GreedyItem>.ChosenItem {
            get {
                return ChosenGreedyItem;
            }
            set {
                ChosenGreedyItem = value;
            }
        }
    }
