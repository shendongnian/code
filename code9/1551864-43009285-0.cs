    public class Main1
        {
            private readonly ListView _lv;
            public Main1(ListView listview)
            {
                _lv = listview;
            }
            public ListView addItemToLV(string text)
            {
                _lv.Items.Add(text);
                return _lv;
            }
        }
