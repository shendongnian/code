        public int DisplayOrder
        {
            get
            {
                if (ServiceCategory == "D")
                {
                    if (CodeDetail == "Modem1")
                        return 1;
                    if (CodeDetail == "Modem2")
                        return 2;
                    if (CodeDetail == "Modem3")
                        return 3;
                    else
                        return 0;
                }
                else
                {
                    return 0;
                }
            }
        }
