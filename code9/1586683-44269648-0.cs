    //this class represents the structure of the data of the lookup_client_name content
    public class RowContent
    {
        public string SomeProperty{ get; set; }
        public string PreserveValues{ get; set; }
    }
    //...
    gv.DataSource = db.lookup_client_name.
                    Select(i => new 
                    { 
                        SomeProperty = i.SomeProperty, 
                        PreserveValues = "'" + i.PreserveValues + "'" 
                    }).ToList();
