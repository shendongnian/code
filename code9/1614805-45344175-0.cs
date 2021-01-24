                   string NS = textBox1.Text;
                   var foundRecord =  File
                      .ReadLines(@"test.csv")
                      .Where(line => line.Contains(NS)).FirstOrDefault();
        
                    if (foundRecord != null)
                    {
                        var cols = foundRecord.Split(';'); //split by (;)
                        var firstVar = cols[0]; //capture column in variable
                        var secondVar = cols[1];
                        var thirdVar = cols[2];
                    }
