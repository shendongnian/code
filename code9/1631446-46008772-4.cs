    var columns = from column in xml.Descendants("column")
                  where 
                      DistanceToRoot(column, xml.Root) == 2  &&
                      column.Attribute("column-name").Value == "abc"
                  select column;
     foreach(var abc in xyzs)
     {
         Console.WriteLine(abc);
         Console.Write("Distance is: ");
         Console.WriteLine(DistanceToRoot(abc, xml.Root));
         Console.ReadLine();
     }
