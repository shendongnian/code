    public class PredicateCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register(() => (Expression<Predicate<string>>) (s => true));
        }
    }
    =====
    var fixture = new Fixture();
    fixture.Customize(new PredicateCustomization());
    var predicateExpr = fixture.Create<Expression<Predicate<string>>>();
