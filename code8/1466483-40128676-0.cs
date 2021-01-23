     interface Asset<out P> where P : Parm { }
----------
    public static class Program
    {
        public static void Main(string[] args)
        {
            List<Asset<Parm>> assets = new List<Asset<Parm>>();
            Stock stock = new Stock();
            assets.Add(stock);
        }
    }
    interface Asset<out P> where P : Parm { }
    abstract class Parm { }
    class StockParm : Parm { }
    class Stock : Asset<StockParm> { }
