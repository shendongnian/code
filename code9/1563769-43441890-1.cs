    class Program
    {
        static void Main(string[] args)
        {
            Elements ListElements = new Elements();
            
            ListElements.ElementValue.Add(3);
            ListElements.ElementValue.Add(10);
            ListElements.ElementValue.Add(43);
            ListElements.ElementValue.Add(100);
            ListElements.ElementValue.Add(30);
            ListElements.ElementValue.Add(140);
            ListElements.CreateDeltaValues();
            for (int i = 0; i < ListElements.DeltaValue.Count; i++)
            {
                Console.WriteLine("ListElement["+i+"]: " + ListElements.DeltaValue[i]);
                //example as for ListElements[2].DeltaValue will be 13; because 43-30=13;
            }
            Console.ReadKey();
        }
    }
    public class Elements
    {
        public List<double> DeltaValue = new List<double>();
        public List<double> ElementValue = new List<double>();
        public void CreateDeltaValues()
        {
            this.ElementValue.Sort();
            for (int i = 1; i < this.ElementValue.Count; i++)
            {
                var deltaValue = this.ElementValue[i] - this.ElementValue[i-1];
                this.DeltaValue.Add(deltaValue);
            }
        }
    }
