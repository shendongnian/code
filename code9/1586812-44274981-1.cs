    public class ItemSize
    {
        public string Unit { get; set; }
        public double Value { get; set; }
    }
    public class SizeComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var itemX =  new ItemSize { Unit = x.Substring(x.Length - 2), Value = double.Parse(x.Substring(0, x.Length - 2)) };
            var itemY = new ItemSize { Unit = y.Substring(y.Length - 2), Value = double.Parse(y.Substring(0, y.Length - 2)) };
            SetItemSize(itemX);
            SetItemSize(itemY);
            return itemX.Value.CompareTo(itemY.Value);
        }
        private void SetItemSize(ItemSize item)
        {
            switch (item.Unit)
            {
                case "KB":
                    item.Value *= 1000;
                    break;
                case "MB":
                    item.Value *= 1000000;
                    break;
                case "GB":
                    item.Value *= 1000000000;
                    break;
                // Add all the other cases
                default:
                    throw new ArgumentException("Looks like you missed one...");
            }
        }
    }
