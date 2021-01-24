    public partial class Root
    {
    	[JsonPropertyAttribute("time")] public long Time { get; set; }
    	[JsonPropertyAttribute("global")] public Global Global { get; set; }
    	[JsonPropertyAttribute("algos")] public Dictionary<string, Algo> Algos { get; set; }
    	[JsonPropertyAttribute("pools")] public Dictionary<string, Pool> Pools { get; set; }
    }
    
    public partial class Global
    {
    	[JsonPropertyAttribute("workers")] public int Workers { get; set; }
    	[JsonPropertyAttribute("hashrate")] public long Hashrate { get; set; }
    }
    
    public partial class Algo
    {
    	[JsonPropertyAttribute("workers")] public int Workers { get; set; }
    	[JsonPropertyAttribute("hashrate")] public double Hashrate { get; set; }
    	[JsonPropertyAttribute("hashrateString")] public string HashrateString { get; set; }
    }
    
    public partial class Pool
    {
    	[JsonPropertyAttribute("name")] public string Name { get; set; }
    	[JsonPropertyAttribute("symbol")] public string Symbol { get; set; }
    	[JsonPropertyAttribute("algorithm")] public string Algorithm { get; set; }
    	[JsonPropertyAttribute("poolStats")] public PoolStats PoolStats { get; set; }
    	[JsonPropertyAttribute("blocks")] public Blocks Blocks { get; set; }
    	[JsonPropertyAttribute("workers")] public Dictionary<string, Worker> Workers { get; set; }
    	[JsonPropertyAttribute("hashrate")] public double Hashrate { get; set; }
    	[JsonPropertyAttribute("workerCount")] public long WorkerCount { get; set; }
    	[JsonPropertyAttribute("hashrateString")] public string HashrateString { get; set; }
    }
    
    public partial class Blocks
    {
    	[JsonPropertyAttribute("pending")] public long Pending { get; set; }
    	[JsonPropertyAttribute("confirmed")] public long Confirmed { get; set; }
    	[JsonPropertyAttribute("orphaned")] public long Orphaned { get; set; }
    }
    
    public partial class PoolStats
    {
    	[JsonPropertyAttribute("validShares")] public string ValidShares { get; set; }
    	[JsonPropertyAttribute("validBlocks")] public string ValidBlocks { get; set; }
    	[JsonPropertyAttribute("invalidShares")] public string InvalidShares { get; set; }
    	[JsonPropertyAttribute("invalidRate")] public string InvalidRate { get; set; }
    	[JsonPropertyAttribute("totalPaid")] public string TotalPaid { get; set; }
    }
    public partial class Worker
    {
    	[JsonPropertyAttribute("shares")] public double Shares { get; set; }
    	[JsonPropertyAttribute("invalidshares")] public long Invalidshares { get; set; }
    	[JsonPropertyAttribute("hashrate")] public double Hashrate { get; set; }
    	[JsonPropertyAttribute("hashrateString")] public string HashrateString { get; set; }
    }
