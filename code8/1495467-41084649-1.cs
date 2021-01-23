    Parse(string str)
            {
                double res = 0;
                string[] p = str.Split(' ');
                
                double multuplier = 1.0;
    
                p.ToList().ForEach(f =>
                {
                    int parsed;
                    if(int.TryParse(f, out parsed))
                    {
                        res += parsed * multuplier;
                        multuplier *= 0.1;
                    }
                });
    
                return res;
            }
