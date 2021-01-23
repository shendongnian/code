    enum Direction
    {
        Increase,
        Decrease,
    }
    class ValueGenerator
    {
        private readonly Random _generator;
        public ValueGenerator( Random generator )
        {
            if ( generator == null )
                throw new ArgumentNullException( nameof( generator ) );
            _generator = generator;
        }
        public double MinInterval { get; set; } = 0;
        public double MaxInterval { get; set; } = 1;
        public double MinValue { get; set; } = 0;
        public double MaxValue { get; set; } = 100;
        public double CurrentValue { get; set; } = 0;
        public Direction CurrentDirection { get; set; } = Direction.Increase;
        public int PossibilityToChangeDirection { get; set; } = 10;
        public double NextValue()
        {
            if ( _generator.Next( PossibilityToChangeDirection + 1 ) == PossibilityToChangeDirection / 2 )
            {
                switch ( CurrentDirection )
                {
                    case Direction.Increase:
                        CurrentDirection = Direction.Decrease;
                        break;
                    case Direction.Decrease:
                        CurrentDirection = Direction.Increase;
                        break;
                    default:
                        throw new InvalidOperationException( );
                }
            }
            var newInterval = ( MaxInterval - MinInterval ) * _generator.NextDouble( ) + MinInterval;
            if ( CurrentDirection == Direction.Decrease )
                newInterval = -newInterval;
            if ( CurrentValue + newInterval < MinValue )
                CurrentValue = MinValue;
            else if ( CurrentValue + newInterval > MaxValue )
                CurrentValue = MaxValue;
            else
                CurrentValue += newInterval;
            return CurrentValue;
        }
    }
