    public class OptionSelector<T>
    {
        private readonly List<Option> options = new List<Option>();
        public T SelectedOption { get; private set; }
    
        public OptionSelector<T> WithOption(T value, string title)
        {
            options.Add(new Option { Value = value, Title = title });
            return this;
        }
        public bool SelectOption()
        {
            if (!options.Any()) return true;            
    
            Console.WriteLine($"Choose one of the {options.Count} options:");    
            for(int i = 0; i < options.Count; i++)
                Console.WriteLine($" {i + 1} - {options[i].Title}");
    
            Console.Write("Your choice: ");
            var key = Console.ReadKey().KeyChar;
            Console.WriteLine();    
            int choice = key - '0';
            if (!Char.IsDigit(key) || choice == 0 || options.Count < choice) {
                Console.WriteLine($"Sorry, only digits 1..{options.Count} are allowed");
                return false;
            }
    
            SelectedOption = options[choice - 1].Value;
            return true;
        }
    
        private class Option {
            public T Value { get; set; }
            public string Title { get; set; }
        }
    }
