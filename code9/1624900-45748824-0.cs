     string[] scores =System.IO.File.ReadAllLines(@"C:\Users\Desktop\ShoeRack.txt");
                    var content=new StringBuilder();  
                  var numbers = scores.OrderBy(x=>(x.Split(',')[2]));
        
                  foreach(var dat in numbers)
                 {
                   content = dat.toString();
                   content.Append(content+Environment.NewLine);
                 }
                 writetoFile(outputFile,content.ToString());
