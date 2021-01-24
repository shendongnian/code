    namespace CompositePatternExercise
    {
        class Custos : CustosNode
        {
                // Constructor
                public Custos(string name, decimal amount, decimal value) : base(name, amount, value)
                {
                }
                public override void Add(CustosNode c)
                {
                    Console.WriteLine(
                      "Cannot add to a custo");
                }
                public override void Remove(CustosNode c)
                {
                    Console.WriteLine(
                      "Cannot remove from a custo");
                }
                public override void Display()
                {
                    Console.WriteLine(_name + " " + Amount.ToString("C") + " " + Value.ToString("C"));
                }
            }
        }
    }
