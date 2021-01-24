    using System.Linq;
    
    int[] data = new[] {1, 2, 3, 4, 5, 3, 2, 4, 1};
	
    // key is the number, value is its count
    var numberCounts = new Dictionary<int, int>();
    foreach (var number in data) {
        if (numberCounts.ContainsKey(number)) {
            numberCounts[number]++;
        }
        else {
            numberCounts.Add(number, 1);
        }
    }
        		
    var noPair = numberCounts.Single(kvp => kvp.Value < 2);
    Console.WriteLine(noPair.Key);
