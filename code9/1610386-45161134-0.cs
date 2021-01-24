     using System.Linq;
     ...
     string test = "hello z";
     // To dump
     string dump = string.Join(" ", test.Select(c => $"0x{(int)c:X2}"));
     // From dump
     string restore = string.Concat(dump
       .Split(' ')
       .Select(item => (char)Convert.ToInt32(item, 16))); 
     Console.WriteLine(dump);
     Console.WriteLine(restore);
