    public interface IVisible {
        void CallMe();
    }
    
    public class Outer {
        private class Hidden : IVisible {
            public void CallMe() {
                Console.WriteLine("I'm hidden!");
            }
        }
        public static IVisible GetObject() {
            return new Hidden();
        }
    }
