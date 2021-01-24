    [TestFixture]
    public class tmp
    {
        [Test]
        public void test()
        {
            var baseAmount = 40000000M;
            var basePrice = 100;
            var percentIncreaseTrigger = 0.00125M;
            var percentDecreaseInPrice = 0.0006M;
            GetNewPrice(baseAmount, basePrice, percentIncreaseTrigger,
                        percentDecreaseInPrice, 40050000)
                .ShouldBe(99.94M);
            GetNewPrice(baseAmount, basePrice, percentIncreaseTrigger, 
                        percentDecreaseInPrice, 40100000)
                .ShouldBe(99.88M);
            GetNewPrice(baseAmount, basePrice, percentIncreaseTrigger, 
                        percentDecreaseInPrice, 40400000)
                .ShouldBe(99.52M);
        }
        private decimal GetNewPrice(decimal baseAmount, decimal basePrice, 
               decimal trigger, decimal decreaseBy, decimal newAmount)
        {
            //work out what the trigger % is as an absolute amount
            var triggerAmount = baseAmount * trigger;
            //work out the price decrease as an absolute amount of the base price
            var priceDecreaseAmount = basePrice * decreaseBy;
            //work out how much over the baseAmount we are
            var amountOver = newAmount - baseAmount;
            //work out how many times we can fit the 0.125% into this - 
            //ignore fractional parts
            var numberOfTriggers = Math.Floor(amountOver / triggerAmount);
            //multiply the priceDecrease amount up by this
            var totalToTakeOffPrice = priceDecreaseAmount * numberOfTriggers;
            var result = basePrice - totalToTakeOffPrice;
            return result;
        }
    }
