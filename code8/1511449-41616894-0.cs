         namespace Prueba1
        {
        class Program
        {
        public class WrapperInt {
            public int Value { get; set; }
        }
        public class SomeObject
        {
            public int Amount { get; set; }
            public WrapperInt TotalAmount { get; set; }
        }
        public Program() {
            WrapperInt TotalAmountAllArrays = new WrapperInt();
            List<SomeObject> myCollection = new List<SomeObject>()
               {
                new SomeObject() { Amount = 3, TotalAmount =TotalAmountAllArrays  },
                new SomeObject() { Amount = 6 , TotalAmount =TotalAmountAllArrays },
                new SomeObject() { Amount = 9 , TotalAmount =TotalAmountAllArrays }
                };
            for (int i = 0; i < myCollection.Count; i++)
            {
                myCollection[i].TotalAmount.Value += myCollection[i].Amount;
            }
            foreach (var c in myCollection)
            {
                Console.WriteLine($"The Amount is:" + c.Amount + "  The total ammount is:" + c.TotalAmount.Value);   
            }
        }
        static void Main(string[] args)
        {
            new Program();
        }
    }
}
