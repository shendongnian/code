        public class BigClass : ISet1
        {
            public string Prop1 { get; set; }
            public string Prop2 { get; set; }
            public string Prop3 { get; set; }
        }
        public interface ISet1
        {
            string Prop1 { get; set; }
            string Prop2 { get; set; }
        }
        public interface ICalculator
        {
            CalculationResult Calculate(ISet1 input)
        }
