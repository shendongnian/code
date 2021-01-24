    public interface IAnimal {
        int GetLegs();
    }
    public class Bird : IAnimal {
        public int GetLegs() {
            return 2;
        }
    }
    public class Cat : IAnimal {
        public int GetLegs() {
            return 4;
        }
    }
