        public class testdata
            {
                public string id { get; set; }
    
                public Command TestCommand
                {
                    get
                    {
    
                        return new Command((o) =>
                        {
                            System.Diagnostics.Debug.WriteLine("Item " + o.ToString());
                        });
                    }
                }
            }
