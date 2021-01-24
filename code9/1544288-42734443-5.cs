    var xyz = "This is Rock Balbao. I am the good guy. I am Awesome! And I am Cool";
                var sw = Stopwatch.StartNew();
            
            var xyzArray = xyz.Split('.','!');
    
            
            for (int i = 0; i < xyzArray.Length; i++)
            {
                xyzArray[i] = xyzArray[i].Trim(); 
                    
            }
             sw.Stop();
    
                //end test1 
                var sw1 = Stopwatch.StartNew();
                string[] xyzArray1 = Array.ConvertAll(
        xyz.Split(new String[] { ".", "!" }, StringSplitOptions.RemoveEmptyEntries),
        x => x.TrimStart()
    );
            sw1.Stop();
            Console.WriteLine("Total milliseconds : " + sw.ElapsedTicks);
            Console.WriteLine("Total milliseconds (ConvertAll) : " + sw1.ElapsedTicks);
