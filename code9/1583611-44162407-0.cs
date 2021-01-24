    public object Passed {
        get
        {
            if (this.Passed.GetType() == typeof(bool))
            {
               return this.Passed == true ? 1 : 0;
            }
            else
            {
                return this.Passed;
            }
        }
