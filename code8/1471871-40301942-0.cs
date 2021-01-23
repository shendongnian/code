    foreach (string line in LogList)
            {
                LineItemCount++;
                //Split on space - need to do this then turn back into alist?
                string LineItem = LineItemCheck = line;
        
            if (LineItem.Substring(0, 1) == "#")
            {
                // we remove this line from the collection.
                ViewBag.RemovedLines += "(" + LineItemCount + ")" + LineItemCheck + "<br>";
            }
            else
            {
                //process it and add to the final "List<LogParser> LogListParsed"
                ViewBag.AddedLines += "(" + LineItemCount + ")" + LineItemCheck.ToString() + "<br>";
            }
        }
