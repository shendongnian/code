    public interface IBankingOperation<T>
    {
        void Withdraw();
    }
    public interface IBankingOperationFactory<T>
    {
        IBankingOperation<T> GetBankingOperation(string name);
    }
    public class BankingOperationOne : IBankingOperation<TestOne>
    {
        public BankingOperationOne()
        {
            Console.WriteLine("Testing Constructor :: One :: Empty");
        }
        public void Withdraw()
        {
            Console.WriteLine("Money Withdrawl Operation One");
        }
    }
    public class BankingOperationTwo : IBankingOperation<TestTwo>
    {
        public BankingOperationTwo()
        {
            Console.WriteLine("Testing Constructor :: Two :: Empty");
        }
        public void Withdraw()
        {
            Console.WriteLine("Money Withdrawl Operation Two");
        }
    }
    public class TestOne { }
    public class TestTwo { }
    // Ninject Bindings
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IBankingOperation<TestOne>>().To<BankingOperationOne>().Named("A");
            Bind<IBankingOperation<TestOne>>().To<BankingOperationOne>().Named("B");
            Bind<IBankingOperation<TestOne>>().To<BankingOperationOne>().WhenInjectedInto(typeof(BankTran<TestOne>));
            Bind<IBankingOperationFactory<IBankingOperation<TestOne>>>().ToFactory();
            Bind<IBankingOperation<TestTwo>>().To<BankingOperationTwo>();
        }
    }
    public class BankTran<T> where T : class
    {
        private IBankingOperation<T> bankingOperation;
        private IBankingOperationFactory<T> _bankingOperationFactory;
        public BankTran(IBankingOperation<T> bo = null,
                        IBankingOperationFactory<T> bankingOperationFactory = null)
        {
            bankingOperation = bo;
            _bankingOperationFactory = bankingOperationFactory;
        }
        public void DoOperation(string identifier = null)
        {
            if (_bankingOperationFactory != null && identifier != null)
                _bankingOperationFactory.GetBankingOperation(identifier).Withdraw();
            else if (bankingOperation != null)
                bankingOperation.Withdraw();
            Console.WriteLine("Transaction Successful ");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new NinjectSettings { AllowNullInjection = true });
            kernel.Load(Assembly.GetExecutingAssembly()); // Load from Bindings (derived from NinjectModule)
            var transaction = kernel.Get<BankTran<TestOne>>();
            transaction.DoOperation();
            transaction.DoOperation("A");
            transaction.DoOperation("B");
        }
    }
