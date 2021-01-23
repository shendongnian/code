                    bool getOut=false;
                    do
                    {
                        tagIDNumber.Clear();
                        TagType = Identify(tagIDNumber, SEGOTAGTYPE);
    
                        if (tagIDNumber.ToString()  == "")
                           getOut=true;
                    }
                    while (tagIDNumber.ToString().ToUpper() != Globals.previoustagIDNumber & getOut==false);
