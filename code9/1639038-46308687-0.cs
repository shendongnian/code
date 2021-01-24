            List<string> guID = new List<string>();
            List<string> name = new List<string>();
            var secBC = from lv1 in xDoc.Descendants("section")
                        .Where(lv1 => (string)lv1.Attribute("fd_name_size") != null)
                        select new
                        {
                            Header = lv1.Attribute("guid").Value,
                            NameSize = lv1.Attribute("fd_name_size").Value  
                        };
            foreach (var lv1 in secBC)
            {
                guID.Add(lv1.Header);   // [0] 112ff6b8-2609-4d19-b774-33ab951ee66a, OK 
                                        // [1] 98948ace-afb2-400d-9d96-752f5fce40c4, OK
                name.Add(lv1.NameSize); // [0] 150x300, OK 
                                        // [1] 300x600, OK
            }
