    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Loan l = new Loan();
                var a = 1;
            }
        }
    
        public interface IDebtBase
        {
            // with properties
        }
    
        public interface IDebt : IDebtBase
        {
            // with properties
        }
    
        public interface ILoanBase<T> where T : IDebtBase
        {
            List<T> Debts { get; set; }
        }
    
        public interface ILoan : ILoanBase<IDebt>
        {
            // with properties
        }
    
        public class Loan : ILoan
        {
            public List<IDebt> Debts { get; set; }
        }
    }
    
