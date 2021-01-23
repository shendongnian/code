    public bool IsStringBuilderWritten
            {
                get { 
                     bool temp = _isStringBuilderWritten;
                     _isStringBuilderWritten = false;
                     return temp; 
                    }
                set { _isStringBuilderWritten = value; 
                      if (IsStringBuilderWritten) { OnstringBuilderWritten(); } 
                    }
            }
