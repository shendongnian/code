    public class TheFooClass
    {
        [Test]
        public void TheFooTest()
        {
            Assert.That(true, Is.True.If(false)); // passes
            Assert.That(true, Is.True.If(true)); // passes
            Assert.That(false, Is.True.If(false)); // passes
            Assert.That(false, Is.True.If(true)); // fails
        }
    }
    public static class AssertionExtensions
    {
        public static Constraint If(this Constraint expression, bool isTrue)
        {
            return isTrue ? expression : new AlwaysTrue();
        }
    }
    public class AlwaysTrue : Constraint
    {
        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            var trueResult = new ConstraintResult(new TrueConstraint(), true);
            trueResult.Status = ConstraintStatus.Success;
            return trueResult;
        }
    }
