    abstract class BaseBuilder<TBrick>
    {
        public BaseBuilder<TBrick> AddBrick(TBrick brick)
        {
            // ...
            return this;
        }
    }
    class Builder : BaseBuilder<ConcreteBrick>
    {
        public Builder AddRoof()
        {
            // ...
            return this;
        }
    }
