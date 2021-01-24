    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                WorldMarket wm = new WorldMarket();
            }
        }
        public class WorldMarket
        {
            internal List<NationBuilder> Nations { get; set; }
            public WorldMarket()
            {
                Nations = new List<NationBuilder>() {
                    new NationBuilder() { 
                        name = "USA", 
                        stockPiles = new List<StockPile>() {
                            new StockPile() { name = "Coal", quantity = 2, value = "value"},
                            new StockPile() { name = "Coal", quantity = 2, value = "value"}
                        }
                    }
                };      
            }
            public void AddToWorldMarket(NationBuilder nation)
            {
                Nations.Add(nation);
            }
        }
        public class NationBuilder
        {
            public string name { get; set; }
            public List<StockPile> stockPiles { get; set; }
        }
        public class StockPile
        {
            public string name { get; set; }
            public int quantity { get; set; }
            public string value { get; set; }
        }
    }
