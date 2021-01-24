    public IEnumerable<SelectedDetails> GetSelectedDetails(string Name)
                {
                    using (var con = new SqlConnection("Data Source=CHANDAKG-01-L\\SQLEXPRESS;initial catalog=Calculator;integrated security=true"))
                    {
                        con.Open();
    
                        string query = @"   SELECT * 
                                            FROM DataNorm 
                                            WHERE Provider= @name 
                                              AND year(DateMonth) = 2014 ";
    
                        var result = con.Query<SelectedDetails>(query, new { name = Name });
    
                        return result;
                    }
                }
