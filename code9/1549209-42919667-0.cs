    List<Row> list = new List<Row>();
    //add data to list
    //then execute this linq query
    list.GroupBy(x => x.SINo).Select(y=> new Row
                {
                    AccountName = y.First().AccountName,
                    ProductCode = y.First().ProductCode,
                    Quantity = y.First().Quantity,
                    SINo = y.First().SINo,
                    FreeGoods = y.Count() > 1 ? y.Last().Quantity : 0
                });
