    public class First {
        [Order(1)]
        public string a { get; set; }
        [Order(2)]
        public string b { get; set; }
    }
    public class Second : First {
        [Order(3)]
        public string c { get; set; }
    }
    public class OrderAttribute : Attribute {
        public int Order {get; set; }
        public OrderAttribute(int order) {
            Order = order;
        }
    }
    class Program {
        static void Main(string[] args) {
            List<Second> list = new List<Second>();
            list.Add(new Second {
                a = "a",
                b = "b",
                c = "c"
            });
            WriteList(list);
        }
        static void WriteList(List<Second> list) {
            PropertyInfo[] properties = typeof(Second).GetProperties();
            int row = 3;
            int col = 0;
            foreach (var item in list) {
                Dictionary<int, object> values = new Dictionary<int, object>();
                foreach (var pi in properties) {
                    var orderAttr = pi.GetCustomAttribute(typeof(OrderAttribute)) as OrderAttribute;
                    if (orderAttr != null) {    //this allow to output selective propertes. Those properties without [order] attriburte will not output
                        values.Add(orderAttr.Order, pi.GetValue(item, null));
                    }
                }
                foreach (var key in values.Keys.OrderBy(x => x)) {
                    ws.Cells[row++, col + key].Value = values[key];
                }
            }
        }
