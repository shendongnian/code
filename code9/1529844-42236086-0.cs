            public string FullName
            {
                get { return FirstName + " " + LastName; }
                set
                {
                    this.FirstName = value.Split(null)[0];
                    this.LastName = value.Split(null)[1];
                }
            }
