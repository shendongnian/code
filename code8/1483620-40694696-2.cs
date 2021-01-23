    public async Task<int> Z() => 0;
    
    void Main()
    {
    	Console.WriteLine(Task.FromResult(0) == Task.FromResult(0)); // false
    	Console.WriteLine(Z() == Z()); // true
    }
