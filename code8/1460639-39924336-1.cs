    Class proc1Result {
        
        //properties for table1
        
        //properties for table2
        
        }
    
     Class model1{
        
        //properties for table1
            
        } 
    Class model2 {
        
        //properties for table2
     
        }
        
        
        ISingleResult<proc1Result> results = datacontext1.proc1(parameter);
        foreach (proc1Result item in results){
            resultList.Add(
                new model2{
                    item.propertyname //which is there in both model2 and proc1result
    
                }
            );
        }
