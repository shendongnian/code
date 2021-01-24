     public static void Main()
        {
            var vm = new ViewModel();
            Console.WriteLine($"Start - {vm}");
            ApplyDefaults(vm);
            Console.WriteLine($"ApplyDefaults - {vm}");
            vm.Name = "Damian";
            vm.Age = 23;
            Console.WriteLine($"After using setters - {vm}");
            ApplyDefaults(vm);
            Console.WriteLine($"After ApplyDefaults - {vm}");
        }
