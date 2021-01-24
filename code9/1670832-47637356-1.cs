    using System;
    using System.Collections.Generic;
    
    namespace CompositePatternExercise
    {
        class Projectos : CustosNode
        {
            private List<CustosNode> elements = new List<CustosNode>();
    
            // Constructor
            public Projectos(string name) : base(name)
            {
            }
    
            public override void Add(CustosNode d)
            {
                elements.Add(d);
            }
    
            public override void Remove(CustosNode d)
            {
                elements.Remove(d);
            }
            public override void Display()
            {
                decimal totalValue = 0;
                decimal totalAmount = 0;
    
                Console.WriteLine(_name);
    
                // Display each child element on this node
                foreach (CustosNode d in elements)
                {
                    d.Display();
                    totalAmount += d.Amount;
                    totalValue += d.Value;
                }
    
                Console.Write("Project total:" + totalAmount.ToString("C") + " " + totalAmount.ToString("C"));
    
            }
        }
    }
