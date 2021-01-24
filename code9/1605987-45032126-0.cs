    var index = "product";
                var type = "product";
    
                var db = new ElasticClient(new Uri("http://localhost:9200"));
    
                await db.DeleteIndexAsync(index);
                
                //I am using dynamic data but you can use your class it's easear as well
                await db.IndexAsync(new 
                {
                    name = "P1", W=200, S=40, P=2500
                }, i=>i.Index(index).Type(type));
    
                await db.IndexAsync(new 
                {
                    name = "P2", W=50, S=10, P=2000
                }, i=>i.Index(index).Type(type));
    
                await db.IndexAsync(new 
                {
                    name = "P3", W=400, S=100, P=1000
                }, i=>i.Index(index).Type(type));
    
                await db.IndexAsync(new 
                {
                    name = "P4", W=200, S=45, P=3000
                }, i=>i.Index(index).Type(type));
    
                await Task.Delay(1000);
    
                //I think there needs to be some sort of normalizations on fields this is a max base normalization so we can use 
                var max = await db.SearchAsync<dynamic>(s =>
                   s.Size(0)
                   .Index(index)
                   .Type(type)
                   .Aggregations(aggr =>
                       aggr
                       .Min("maxWeight", f => f.Field("w"))
                       .Max("maxPrice", f => f.Field("s"))
                       .Max("maxSize", f => f.Field("p"))));
    
                // This is to calculate the factors the max value is to normalize multivariable data so all the values be on scale from 0-1
                //The max value will allways be 1 and the othhers will be a precentage of the max value this will only work for none negative values
                // You can use some other way of normalizing but this depends on the data.
                var paramsData1 = new
                {
                    Weight = (10 - 5) / max.Aggs.Max("maxWeight").Value,
                    Price = 3 / max.Aggs.Max("maxPrice").Value,
                    Size = 8 / max.Aggs.Max("maxSize").Value
                };
    
                // The first query is based on busting the fields based on factors entered
                var items = await db.SearchAsync<dynamic>(s =>
                    s.Index(index)
                    .Type(type)
                    .Query(q => q.FunctionScore(fs =>
                        fs.Functions(ff =>
                            ff.FieldValueFactor(fvf => fvf.Field("w").Factor(paramsData1.Weight))
                            .FieldValueFactor(fvf => fvf.Field("s").Factor(paramsData1.Size))
                            .FieldValueFactor(fvf => fvf.Field("p").Factor(paramsData1.Price)))
                        .BoostMode(FunctionBoostMode.Sum))));
    
                System.Console.WriteLine("______________________________");
                foreach (var item in items.Hits)
                {
                    System.Console.WriteLine($"Name:{item.Source.name};S:{item.Source.s};W:{item.Source.w};P:{item.Source.p};");
                }
    
    
                var paramsData2 = new
                {
                    //this is to reverse the data since from what I can tell lower is better
                    Weight =(10 - 10) / max.Aggs.Max("maxWeight").Value,
                    Price = 0 / max.Aggs.Max("maxPrice").Value,
                    Size = 5 / max.Aggs.Max("maxSize").Value
                };
                
                //You can write you own score function and by hand if needed and do some sort of calculation.
                var itemsScript = await db.SearchAsync<dynamic>(s =>
                    s.Index(index)
                    .Type(type)
                    .Query(q => q.FunctionScore(fs => fs.Functions(ff =>
                        ff.ScriptScore(
                        ss =>
                            ss.Script(script => script.Params(p =>
                                p.Add("Weight", paramsData2.Weight)
                                .Add("Price", paramsData2.Price)
                                .Add("Size", paramsData2.Weight))
                                .Inline("params.Weight * doc['w'].value + params.Price * doc['p'].value + params.Size * doc['s'].value")))))));
    
                System.Console.WriteLine("______________________________");
                foreach (var item in itemsScript.Hits)
                {
                    System.Console.WriteLine($"Name:{item.Source.name};S:{item.Source.s};W:{item.Source.w};P:{item.Source.p};");
                }
