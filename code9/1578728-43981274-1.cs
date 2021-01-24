    private class ScrewItUp : IComparable<double>
    {
    	public int CompareTo(double value) => 0;
    }
    
    List<IComparable<double>> list = new List<double>(); // you propose that this work.
    list.Add(new ScrewItUp()); // What's this supposed to do, then?
