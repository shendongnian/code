    public class Item {
        ...
        public static Item FromPipeDelimitedText(string text) {
            var arr = text.Split(new [] { '|' };
            return new Item(arr[0], arr[1]);
        }
    }
