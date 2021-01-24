      public string Name
            {
                get { return _name; }
                private set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                        _name = value;
                    else
                    {
                        throw new Exception("Exception");
                    }
                }
            }
