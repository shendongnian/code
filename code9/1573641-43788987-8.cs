    public interface Animal {
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
    public int GetLegs(IAnimal animal) {
        return animal.GetLegs();
    }
