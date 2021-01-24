        class DogDictionary : Dictionary<string, object>
        {
            public virtual void Add(KeyValuePair<string, object> item)
            {
                if (item.Value.GetType().ToString().ToUpper().Contains("DOG"))
                    throw new ApplicationException("Invalid Data Type for Value.  Should Have 'Dog' in the Object Name");
            }
        }
