        [ComVisible(false)]
            public virtual int ReadTimeout {
                get {
                    Contract.Ensures(Contract.Result<int>() >= 0);
                    throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_TimeoutsNotSupported"));
                }
                set {
                    throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_TimeoutsNotSupported"));
                }
            }
     
            [ComVisible(false)]
            public virtual int WriteTimeout {
                get {
                    Contract.Ensures(Contract.Result<int>() >= 0);
                    throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_TimeoutsNotSupported"));
                }
                set {
                    throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_TimeoutsNotSupported"));
                }
            }
