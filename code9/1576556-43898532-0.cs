     public bool IsProtected
        {
            get
            {
                return GetXmlNodeBool(_isProtectedPath, false);
            }
            set
            {
                SetXmlNodeBool(_isProtectedPath, value, false);
                if (value)
                {
                    AllowEditObject = true;
                    AllowEditScenarios = true;
                }
                else
                {
                    DeleteAllNode(_isProtectedPath); //delete the whole sheetprotection node
                }
            }
        }
