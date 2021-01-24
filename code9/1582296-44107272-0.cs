    public void MyMethod<T> (){
        var listOfLayers = new ObservableCollection<T>();
    
        if (typeof(T) == typeof(Class1))
        {
           listOfLayers = (ObservableCollection<T>) cOne;    
        }
        else{
           listOfLayers = (ObservableCollection<T>) cTwo;  
        }
    
        foreach (var entry in listOfLayers){
            WL entry.someprop;
        }
    }
