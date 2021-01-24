    bool IsValidIn()
                {
                    foreach (Control c in panel1.Controls)
                    {
                        if (c is SpellBox)
                        {
                            //SpellBox txt = (SpellBox)c;
                            string error = string.Empty;
                            if (epForeName.GetError(c).Length > 0)
                                error = "epForeName";
                            else if(epSurname.GetError(c).Length > 0)
                                error = "epSurname";
                            .
                            .
                            .
                            else if(epEmail.GetError(c).Length > 0)
                                error = epEmail;
                            {
                                if(error != String.Empty) 
                                    return false; 
                            }
                        }
                    }
                    return true;}
