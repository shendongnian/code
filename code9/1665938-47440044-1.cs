    private void save(object sender, RoutedEventArgs e)
    {
        try
        {
            
            using (var db = new testsEntities())
            {
                if (Datag.ItemsSource == null) 
                    return; //Or throw
                var listOfItems = (IEnumerable<Test_table>)Datag.ItemsSource;
                foreach(var item in listOfItems)
                {
                    var model = db.Test_table.FirstOrDefault(x=>x.Id == item.Id)
                    if (model?.Id > 0)
                    {
                        model.names = item.names;
                        model.number = item.number;
                        db.Entry(model).State = EntityState.Modified;
                    }
                    else
                        db.Test_table.Add(item);
        
                    db.SaveChanges();
                }
                
            }
        }
        catch (Exception e)
        {
             //Do Something
        }
    }
