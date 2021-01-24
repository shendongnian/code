    class Pipeline<TInput, TOutput>
    {
        private readonly Func<TInput, TOutput> function;
        
        public Pipeline(Func<TInput, TOutput> function)
        {
            this.function = function;
        }
        
        public Pipeline<TInput, TNext> Then<TNext>(Func<TOutput, TNext> nextFunction) =>
            new Pipeline<TInput, TNext>(input => nextFunction(function(input)));
                                        
        public TOutput Process(TInput input) => function(input);
    }
    
    class Test
    {
        static void Main()
        {
            Pipeline<int, double> pipeline = new Pipeline<int, int>(x => 3)
                .Then(x => x + 3)
                .Then(x => x + 30)
                .Then(x => x * 0.2);
            
            var result = pipeline.Process(6);
            Console.WriteLine($"Result: {result}");
        }
    }
