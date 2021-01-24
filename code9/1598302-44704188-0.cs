    using System;
    using System.Globalization;
    namespace ConsoleApplication1
    {
    class PriceObject
    {
        public string origination { get; set; }
        public string destination { get; set; }
        public DateTime time { get; set; }
        public decimal price { get; set; }
        public PriceObject(string inputLine, char delimiter)
        {
            string[] parsed = inputLine.Split(new char[] { delimiter }, 4);
            origination = parsed[0];
            destination = parsed[1];
            time = DateTime.ParseExact(parsed[2], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            price = Decimal.Parse(parsed[3], NumberStyles.Currency, new CultureInfo("en-US"));
        }
        public override bool Equals(object obj)
        {
            var item = obj as PriceObject;
            return origination.Equals(item.origination) &&
                destination.Equals(item.destination) &&
                time.Equals(item.time) &&
                price.Equals(item.price);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var result = 17;
                result = (result * 23) + origination.GetHashCode();
                result = (result * 23) + destination.GetHashCode();
                result = (result * 23) + time.GetHashCode();
                result = (result * 23) + price.GetHashCode();
                return result;
            }
        }
    }
    }
