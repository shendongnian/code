    List<string> lNotinfiles = new List<string>();
                for(int i = 0; i < files.Count(); i++)
                foreach (var s in files)
                 {
                    var s2 = (from s3 in lProductsList where s.Contains(s3.cProductCode) select s3.cProductCode).FirstOrDefault();
                    if (s2 == null)
                       {
                          lNotinfiles.Add(s);
                       }
                 }
