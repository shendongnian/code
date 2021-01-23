    var nums = new Dictionary<int, string>();
    
                var i = 1;
                while(i <= 4)
                {
                    nums.Add(i, $"Command {i}");
                    i++;
                }
    
                foreach(var item in nums)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
