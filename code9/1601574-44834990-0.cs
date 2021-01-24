    public class FruitProcessingResult
    {
        public bool FruitWasFound { get; set; }
        public Fruit FruitMeetingCondition { get; set; }
        public Task RemainingProcessing { get; set; }
    }
        private async Task<FruitProcessingResult> ProcessFruitBasket(List<Fruit> fruits)
        {
            var result = new FruitProcessingResult();
            //Kick off all fruit processing
            var tasks = fruits.Select(f => ProcessAndTestFruit(f, result)).ToList();
            while (tasks.Any())
            {
                var completed = await Task.WhenAny(tasks);
                tasks.Remove(completed);
                lock (result)
                {
                    if (result.FruitWasFound)
                    {
                        result.RemainingProcessing = Task.WhenAll(tasks);
                        return result;
                    }
                }
            }
            result.RemainingProcessing = Task.CompletedTask;
            return result;
        }
        private async Task ProcessAndTestFruit(Fruit fruit, FruitProcessingResult result)
        {          
            //Process each individual fruit async if you can, otherwise kick off a task
            await ProcessFruitAsync(fruit);
            //await Task.Run(() => ProcessFruitAsync(fruit));
            if (fruit.MeetsSomeCondition())
            {
                lock (result)
                {
                    if (!result.FruitWasFound)
                    {
                        result.FruitWasFound = true;
                        result.FruitMeetingCondition = fruit;
                    }
                }
            }
        }
