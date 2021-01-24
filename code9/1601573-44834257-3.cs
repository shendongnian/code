        public async Task ProcessFruitBasket(IList<Fruit> fruits, Action<Fruit> callBack)
        {
            foreach (var fruit in fruits)
            {
                var process = ProcessFruit(fruit); // DO NOT await here
                // do something else here
                await process; // you have to await here since you have to check condition on processed fruit
                if (fruit.MeetsSomeCondition())
                {
                    callBack(fruit);
                }
            }
        }
        public async Task ProcessFruit(Fruit fruit)
        {
            // do async actions here
            await Task.FromResult<int>(0);
        }
        public void Callback(Fruit fruit)
        {
            // Do something with the fruit
        }
