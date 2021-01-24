            var i = 0;
            var pos = 0;
            DateTime? date = null;
            while (i < StockData.Count && StockData.ElementAt(i)?.High_Low_Price != null )
            {
                pos = i;
                date = StockData.ElementAt(i).Date;
                i++;
            }
