	static void Main(String[] args) {
		var allRecords = new List<Record>();
		foreach (var line in File.ReadLines("Budget.txt")) {
			allRecords.Add(new Record(line));
		}
	}
    public class Record {
    	public string ProductId { get; private set; }
    	public string ProductName { get; private set; }
    	public string CustomerId { get; private set; }
    	public string CustomerName { get; private set; }
    	public decimal Amount { get; private set; }
    
    	public Record(string line) {
    		var items = line.Split();
    		ProductId = items[0];
    		ProductName = items[1];
    		CustomerId = items[2];
    		CustomerName = items[3];
    		Amount = Convert.ToDecimal(items[4]);
    	}
    
    	public override String ToString() {
    		return $"ProductId:{ProductId}, ProductName:{ProductName}, CustomerId:{CustomerId}, CustomerName:{CustomerName}, Amount:{Amount}";
    	}
    
    }
