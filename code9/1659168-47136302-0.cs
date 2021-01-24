    namespace ConsoleApp1 {
    
        public class Control {
            public Control(string name) {
                this.Name = name;
            }
    
            public string Name { get; set; }
        }
    
        class Program {
            static void Main(string[] args) {
                var list1 = new List<Control> { new Control("a"), new Control("b"), new Control("c") };
                var list2 = new List<Control> { new Control("a"), new Control("b"), new Control("c") };
                var list3 = new List<Control> { new Control("a"), new Control("b"), new Control("c") };
    
                foreach (var ctrl in GetList(list1, list2, list3).Where(c => c.Name.StartsWith("a"))) {
                    ctrl.ForeColor = Color.FromArgb(rr, gg, bb);
                }
            }
    
            private static IEnumerable<Control> GetList (params IEnumerable<Control>[] controls) {
                return controls.SelectMany(x => x);
            }
        }
    }
