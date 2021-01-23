                    foreach (Row row in rows)
                {
   
                   object a = row["name"];
                    string[] arr = ((IEnumerable)a).Cast<object>()
                                     .Select(x => x.ToString())
                                     .ToArray();
                    int ab = arr.Length;
                 /*for all items*/
                    for(int i=0; i<ab;i++)
                    {
                        ltr.AppendText(arr[i]+","+i+" | ");
                    }
    /*for only last item*/
                string lastItem = arraystring[length - 1];
                    
                }
