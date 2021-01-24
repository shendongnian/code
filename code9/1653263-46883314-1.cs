    ObservableCollection<Test> coll1 = new ObservableCollection<Test>();
                coll1.Add(new Test{ Id = 1 });
                coll1.Add(new Test{ Id = 2 });
                coll1.Add(new Test{ Id = 3 });
    
    ObservableCollection<Test> coll2 = new ObservableCollection<Test>();
                foreach (var item in coll1)
                {
                    coll2.Add(item.Clone() as Test);
                }
    
                coll2[0].Id = 1500;
