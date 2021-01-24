    public class Greeter {
        public Greeter(string name) {
            _Name = name;
        }
        private string _Name;
        public string SayHello() {
            return $"Hello {_Name}";
        }
        public string SayGoodBye() {
            return $"So long {_Name}, and thanks for all the fish!";
        }
    }
