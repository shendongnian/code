    private void Validate()
            {
                var query = SubModules.GroupBy(s => s.Name)
                                      .Select(s => new { Key = s.Key, Count = s.Count() });
    
                if(query.Any(a => a.Count > 1))
                {
                    /* raise notification with some error message or use RasiePropertyChanged("InValid") 
                     * where InValid property in VM is bing to your XAML for indicating error*/
                }
            }
