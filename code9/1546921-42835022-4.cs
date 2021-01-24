    string[] _codes;
    public string[] Codes
    {
        get
        {
            if (_codes == null) // check if not initialized yet
            {
                _codes = ... // fill from database
            }
            return codes;
        }
    }
