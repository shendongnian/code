    class Man
    {
        private string _name;
        public Man(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null)
                {
                    throw new InvalidInputCustomException("null is not valid for input.");
                }
                else if (value == string.Empty)
                {
                    throw new InvalidInputCustomException("empty is not valid for input.");
                }
                else
                {
                    foreach (char ch in value)
                    {
                        if (!(ch >= 'A' && ch <= 'Z') && !(ch >= 'a' && ch <= 'z') &&
                            !(ch >= '0' && ch <= '9'))
                        {
                            throw new InvalidInputCustomException($"non English character {ch} is " +
                                $"not valid for input."); ;
                        }
                    }
                }
                _name = value;
            }
        }
    }
