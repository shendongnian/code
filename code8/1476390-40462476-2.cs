    class TempObject {
        public TempObject(Handlers handlers) {
            handlers.AddHandler<object>(o => {
                Console.WriteLine(o + this.Name);
            });
        }
        public string Name { get; set; }
    }
