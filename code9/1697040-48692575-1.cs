        public class SeatRestriction
        {
            public Predicate<PassangerModel> Restriction { get; private set; }
            public SeatRestriction(Predicate<PassangerModel> restriction)
            {
                Restriction = restriction;
            }
        }
