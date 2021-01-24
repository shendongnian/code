    public int Numfatura
            {
                get
                {
                    return this._transaction.TransDocument + this._transaction.TransSerial + this._transaction.TransDocNumber;
                }
            }
