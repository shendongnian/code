     class Subtraction<T, U> : IOperation<T, U>
     {
         public T FirstOperand { get; set; }
         public U SecondOperand { get; set; }
     
         public int Result
         {
             get
             {
                 dynamic first = FirstOperand;
                 dynamic second = SecondOperand;            
                 return (int)(first - second);
             }
         }
     }
