    Dictionary<MyActionEnum, Func<Task<decimal>>> tasks = new Dictionary<MyActionEnum, Func<Task<decimal>>> {
                    { MyActionEnum.A1, __Task1 },
                    { MyActionEnum.A2, __Task2 },
                    { MyActionEnum.A3, __Task3 },
                    { MyActionEnum.A4, __Task4 },
                    { MyActionEnum.A5, async () => { return await Task.Delay(5000).ContinueWith(result =>  new Decimal(16)); } }
                };
    static async Task<decimal> __Task1() { return await Task.FromResult<decimal>(new Decimal(420)); }
    // etc
