    bool IsValidIn()
                {
                    foreach (Control c in panel1.Controls)
                    {
                        if (c is SpellBox)
                        {
                            //SpellBox txt = (SpellBox)c;
                            string errorStr = string.Empty;
                            if (epForeName.GetError(c).Length > 0)
                                errorStr = "epForeName";
                            else if(epSurname.GetError(c).Length > 0)
                                errorStr = "epSurname";
                            .
                            .
                            .
                            else if(epEmail.GetError(c).Length > 0)
                                errorStr = "epEmail";
                            
                            if(errorStr != String.Empty) 
                                return false; 
                            
                        }
                    }
                    return true;}
