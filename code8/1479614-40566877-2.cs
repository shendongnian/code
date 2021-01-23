    public class HomeWork
    {
        private IOutput _output;
        public HomeWork(IOutput output)
        {
            _output = output;
        }
        public void Run()
        {
            _output.WriteLine("Give me an integer:");
            var stringValue = _output.ReadLine();
            int number;
            if (int.TryParse(stringValue, out number))
                _output.WriteLine($"The double of {number} is {number * 2}");
            else
                _output.WriteLine($"Wrong input! '{stringValue}' is not an integer!");
            _output.Read();
        }
    }
