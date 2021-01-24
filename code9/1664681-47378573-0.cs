    try
    {
           foreach (KeyValuePair<Type, string> pair in _dictionary)
            {
                var test = _input.Length;
                // TODO: See if substring does not impose a to harsh performance drop
                Match match = Regex.Match(_input.Substring(_counter), pair.Value);
                if (match.Success)
                {
                    if (pair.Key.IsSubclassOf(typeof(AbstractToken)))
                    {
                        // Create new instance of the specified type with the found value as parameter
                        AbstractToken token = (AbstractToken)Activator.CreateInstance(pair.Key, new object[] { match.Value, _counter }, null);
                        return token;
                    }
                }
            }
    }
    catch{ }
