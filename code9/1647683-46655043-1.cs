     DataTable CSVData = new DataTable(); // your csv rows
                
                
                 
                HashSet<Rootobject> MyObjectsList = new HashSet<Rootobject>(); //create hashset to handle your classes
                foreach(DataRow row in CSVData.Rows)
                {
                    //change the indices in ItemArray with the right indices
                    MyObjectsList.Add(new Rootobject() {
                        id = (int)row.ItemArray[0], name = (string)row.ItemArray[0], category = new Category() {
                            id = (int)row.ItemArray[0], name = (string)row.ItemArray[0], subcategory = new Subcategory() {
                                id = (int)row.ItemArray[0], name = (string)row.ItemArray[0]
                            }
                        }
                    });
    
    
                }
    
    
    
    
    
                string _ResultObj = JsonConvert.SerializeObject(MyObjectsList);  //here get your json string
