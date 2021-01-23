            if (objCZKEM.Connect_Net(IPAdd, Port))
            {
                //65535 or 32767- depends
                if (objCZKEM.RegEvent(1, 32767))
                {
                    // [ Register your events here ]
                    // [ Go through the _IZKEMEvents_Event class for a Ex);
                }
                return true;
            }
