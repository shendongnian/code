    public class DiamondKataTestClass1
    {
        [Property()]
        public Property testThatAssumesValidCharWasProvided()
        {
            Prop.ForAll(Arbitraries.LetterGenerator()) (letter =>
            // test here
            )
        }
    }
