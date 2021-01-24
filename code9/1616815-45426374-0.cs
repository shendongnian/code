        void Main()
        {
            string priceList = "1,2,3,4";
            string costList = "2,3,4,5";
            var prices = priceList.Split(new string[1] { "," }, StringSplitOptions.RemoveEmptyEntries);
            var costs = costList.Split(new string[1] { "," }, StringSplitOptions.RemoveEmptyEntries);
            var collectionToUpdate = prices.Zip(costs, (price, cost) => new PriceToUpdate(price, cost));  
           //do update in database with collectionToUpdate
        }
        public class PriceToUpdate
        {
            public PriceToUpdate(string oldPrice, string newPrice)
            {
                decimal priceTmp;
                if (decimal.TryParse(oldPrice, out priceTmp))
                {
                    OldPrice = priceTmp;
                }
                if (decimal.TryParse(newPrice, out priceTmp))
                {
                    NewPrice = priceTmp;
                }
            }
            public decimal OldPrice { get; set; }
            public decimal NewPrice { get; set; }
        }
