    public class ButtonCollection : CollectionBase {
    public CustomButton this[int i] {
      get { return InnerList[i] as CustomButton; }
      set { InnerList[i] = value; }
    }
    public ButtonCollection() {
    }
    public CustomButton Add(CustomButton bt) {
      InnerList.Add(bt);
      return bt;
    }
    public void AddRange(CustomButton[] bts) {
      InnerList.AddRange(bts);
    }
    public void Remove(CustomButton bt) {
      InnerList.Remove(bt);
    }
    public bool Contains(CustomButton bt) {
      return InnerList.Contains(bt);
    }
    public CustomButton[] GetValues() {
      CustomButton[] bts = new CustomButton[InnerList.Count];
      InnerList.CopyTo(bts);
      return bts;
    }
