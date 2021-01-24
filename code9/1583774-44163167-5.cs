        public string Value
        {
            get
            {
                if (!HasValue)
                {
                    return null;
                }
                else
                {
                    return Buffer.Substring(Offset, Length);
                }
            }
        }
