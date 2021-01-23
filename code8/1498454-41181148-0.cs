    enum Day {Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
    public static class DayExtensions
    {
        public static Single GetRate(this Day d)
        {
            switch( d )
            {
                case Day.Saturday:
                    return 1.5f;
                case Day.Sunday:
                    return 2f;
                default:
                    return 1f;
            }
        }
    }
    
