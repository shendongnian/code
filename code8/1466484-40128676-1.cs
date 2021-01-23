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
    public abstract class Parm { }
    public class StockParm : Parm { }
    public interface Asset<out P> where P : Parm { }    
    public class Stock : Asset<StockParm> { }
