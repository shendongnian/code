    public class Reward : Brain<int> // int is now the generic type argument
    {
        public override void Set(Point state, Direction direction, int reward)
        {
            r[Tuple.Create(state, direction)] = reward;
        }
        public int Get(Point state, Direction direction)
        {
            return r[Tuple.Create(state, direction)];
        }
    }
    public class Quantity : Brain<decimal>
    { ... }
