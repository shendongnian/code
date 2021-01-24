    [TestFixture]
    [Description("Users should be able to buy groceries via the web application")]
    public class UsersCanBuyGroceries
    {
        [Test,Screenplay]
        [Description("Joe should see a thankyou message when he uses the web application to buy eggs.")]
        public void JoeShouldSeeAThankyouMessageWhenHeBuysEggs(ICast cast, BrowseTheWeb browseTheWeb)
        {
            var joe = cast.Get("Joe")
            joe.IsAbleTo(browseTheWeb);
            Given(joe).WasAbleTo(SearchTheShop.ForGroceries());
            When(joe).AttemptsTo(Click.On(GroceriesForSale.BuyEggsButton));
            var message = Then(joe).ShouldSee(TheText.Of(GroceriesForSale.FeedbackMessage));
            Assert.That(message, Is.EqualTo("Thankyou for buying eggs."));
        }
    }
