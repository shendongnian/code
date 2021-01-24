            public string this[string columnName]
            {
                get
                {
                    if (!showValidation)
                    {
                        return null;
                    }
