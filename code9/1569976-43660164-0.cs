    private string _firstName;
        public string FirstName
        {
            get { return this._firstName; }
            set
            {
                if (Regex.Match(value, YOUR_REGEX).Success)
                    this._firstName = value;
            }
        }
