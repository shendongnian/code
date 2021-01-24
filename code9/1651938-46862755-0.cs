    public static class Arbitraries
    {
        public static Arbitrary<char> LetterGenerator()
        {
            return Gen.Elements(wholeAlphabet).ToArbitrary();
        }
    }
    public class DiamondKataTestClass1
    {
        [Property(Arbitrary=new[] { typeof<Arbitraries> })]
        public void testThatAssumesValidCharWasProvided(char lettersOnlyHERE)
        {
            // ?
        }
    }
