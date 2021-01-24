            ObservableCollection<ObjType> obsCollectionA = new ObservableCollection<ObjType>();
            ObservableCollection<ObjType> obsCollectionB = new ObservableCollection<ObjType>();
  
            foreach (var pair in obsCollectionA.Zip(obsCollectionB, (a, b) => new { A = a, B = b }))
            {                
                pair.A.Id   =   pair.B.Id;
                pair.A.Name =   pair.B.Name;
                pair.A.Age  =   pair.B.Age;
            }
