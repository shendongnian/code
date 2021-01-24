    foreach (JToken data in jsonInputObj["Data"])
    {
         List<CandleStick> candleArray = new List<CandleStick>();
        
         int i = 1;
         int finalCount = data["CandleCollection"].Count();
         foreach (JToken candleStick in data["CandleCollection"])
         {
              if (i == 1 || i == finalCount) continue;
              i += 1;
              double open = candleStick["Open"].ToObject<double>();
              double high = candleStick["High"].ToObject<double>();
              candleArray.Add(new CandleStick(open, high));
         }
         CandleCollection candleList = new CandleCollection(candleArray);
         symbolList.Add(data["Symbol"].ToString(), candleList);
    }
