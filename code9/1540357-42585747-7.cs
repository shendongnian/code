    var L = new List<MyDataObject>();
    for(int z = 0; z < list_Exp.Count; z++)
    {
        var d = new MyDataObject();
        d.Amount = (goalexp - currentexp) / Convert.ToInt32(list_Exp[z]);
        d.Lose = d.Amount * (list_Amount_MadeFrom_One[z] * list_BuyPrice_MadeFrom_One[z] + list_Amount_MadeFrom_Two[z] * list_BuyPrice_MadeFrom_Two[z]);
        // d.SellPrice = list_SellPrice[z];
        d.Gain = d.Amount * list_AmountMade[z] * list_SellPrice[z];
        d.Cost = d.Gain - d.Lose;
        L.Add(d);
    }
