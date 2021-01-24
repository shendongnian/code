    class A
    {
    	public override int GetHashCode()
        {
    		Console.WriteLine(this.GetType().BaseType.Name);
    		return 0;
    	}
    }
