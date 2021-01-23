            //Collecting the supported keys
            IPortableDeviceKeyCollection keys;
            properties.GetSupportedProperties(objectId, out keys);
            //Init
            _tagpropertykey key = new _tagpropertykey();
            uint count = 0;
            keys.GetCount(ref count);
            //temporarily store each key and display
            for (uint i = 0; i < count; i++)
            {
                keys.GetAt(i, ref key);
                Console.WriteLine("fmtid " + key.fmtid + " pid " + key.pid);
            }
