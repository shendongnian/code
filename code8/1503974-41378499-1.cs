     [HttpPost]
            public int SetEF(string item)
            {
                int pos;
                switch (item)
                {
                    case "2017":
                        pos = 0;
                        TempData["EF"] = 2017;
                        return pos;
    
                    case "2018":
                        pos = 1;
                        TempData["EF"] = 2018;
                        return pos;
    
                    case "2019":
                        pos = 2;
                        TempData["EF"] = 2019;
                        return pos;
    
                    case "2020":
                        pos = 3;
                        TempData["EF"] = 2020;
                        return pos;
    
                    default:
                        return 0;
                }
     }
