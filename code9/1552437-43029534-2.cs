    public class MyLabel: Label {
        public static Dictionary<Button, MyLabel> ParentMap = new Dictionary<Button, MyLabel>();
        public Button btn;
        public string mydata;
        public void AddToParentMap() => ParentMap[btn] = this;
    }
