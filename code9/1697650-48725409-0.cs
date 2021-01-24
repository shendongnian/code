     public class WardModel : BindableBase
        {
            private string _Id;
            public string Id
            {
                get { return _Id; }
                set
                {
                    if(!string.IsNullOrWhiteSpace(value)) SetProperty(ref _Id, value);
                }
            }
        }
