    public void processData()
    {
        var hcols = Input.Columns.Take(Input.Columns.Count).ToList();
        var childNodes = new List<string>();
        var parentNode = "Default";
        for (var i= 1 ; i < hcols.Count -1 ; i++)
        {
            var splitString = hcols[i].Name.Split('_');
            if (nodes.ContainsKey(splitString[0]))
            {
                childNodes.Add(splitString[1]);
            }
            else
            {
                var childNodes2 = new List<string>(childNodes); // depending on your case, you may want a copy here too
                if (!nodes.ContainsKey(splitString[0]) && childNodes.Count > 0)
                {
                    nodes[parentNode] = childNodes2;
                }
                nodes.Add(splitString[0], null);
                parentNode = splitString[0];
                childNodes = new List<string>(); // instead of clear 
                if (splitString.Length > 1) childNodes.Add(splitString[1]);
            }
            Array.Clear(splitString, 0, splitString.Length);
        }
        nodes[parentNode] = childNodes;
    }
