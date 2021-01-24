    namespace CompositePatternExercise
    {
        abstract class CustosNode
        {
            protected string _name;
            protected decimal _amount = 0m;
            protected decimal _value = 0m;
    
            public decimal Value { get => _value; }
            public decimal Amount { get => _amount; }
    
            // Constructor
            public CustosNode(string name)
            {
                this._name = name;
            }
            public CustosNode(string name, decimal amount, decimal value)
            {
                this._name = name;
                this._amount = amount;
                this._value = value;
            }
            public abstract void Add(CustosNode c);
            public abstract void Remove(CustosNode c);
            public abstract void Display();
        }
    }
