    void Main()
    {
    	var list = new ObservableCollection<Animal>();
    
    	list.RegisterPropertyChangeHook(OnPropertyChange);
    	
	    var animal = new Animal(); // Has a "Name" property that raises PropertyChanged
	    list.Add(animal);
	    animal.Name="Charlie"; // OnPropertyChange called
	
	    list.Remove(animal);
	    animal.Name="Sam"; // OnPropertyChange not called
    }
    
    private void OnPropertyChange(object sender, PropertyChangedEventArgs e)
    {
    	Console.WriteLine($"property changed: {e.PropertyName}");
    }
