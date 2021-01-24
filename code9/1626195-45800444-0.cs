     var invoiced = new List<Anonim> 
                    { 
                    new Anonim {Category = 1, Title = "Legal", Amount = 20},
                    new Anonim {Category = 2, Title = "Accounting", Amount = 10}
                    };
                var settled = new List<Anonim> {
                    new Anonim {Category = 1, Title = "Legal", Amount = 10}
                    };
                List<Anonim> credit = new List<Anonim> {
                    new Anonim {Category = 1, Title = "Legal", Amount = 30},
                    new Anonim {Category = 2, Title = "Accounting", Amount = 20}
                    };
    
                List<Result> x = new List<Result>();
                x.AddRange(invoiced.Select(y => new Result { Title = y.Title, Invoiced = y.Amount }));
                x.AddRange(settled.Select(y => new Result { Title = y.Title, Invoiced = y.Amount }));
                x.AddRange(credit.Select(y => new Result { Title = y.Title, Invoiced = y.Amount }));
