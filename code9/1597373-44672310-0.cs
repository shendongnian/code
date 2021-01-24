     //Here I'm not including 59 in the sub arrays  
           var largeBytes = new byte[] {70,68,49,59,117,49,59,112};
            var lists = new List<List<byte>>();
            const int marker = 59;
            var tempLst = new List<byte>();
            foreach (var largeByte in largeBytes)
            {
                
               
                if (largeByte==marker)
                {
                    lists.Add(tempLst);               
                    tempLst=new List<byte>();
                }
                else
                {
                    tempLst.Add(largeByte);    
                }
                
            }
            lists.Add(tempLst);
