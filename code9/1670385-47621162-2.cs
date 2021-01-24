    private async void GetRootObjectItems()
            {
                RootObject emps = await apiServices.GetRootObject();   //Get the root object
                RootObjects.Clear();                        //clear the list
    
                foreach (var item in emps.Items)    //Important, to get the data from the Array on the RootObject
                {
                    ///its a nice way to give your viewmodel a ctor signature that ensures a correct initialization
                    ///public RootItemViewModel(Item item)
                    ///{ 
                    /// this.Deptno = item.Deptno;
                    ///}
                    RootObjects.Add(new RootItemViewModel(item));  
                }
            }
        }
