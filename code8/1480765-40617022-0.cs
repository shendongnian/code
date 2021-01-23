    public static void JsonFileDump(string path)
    {
        //Parse the data
        string jsonStr = File.ReadAllText(path);
        JToken token = JToken.Parse(jsonStr);	// get parent token
        JsonTokenDump(token);
	}
	
    public static void JsonTokenDump(JToken node, int lvl = 0, string nodeName = null)
    {
        if (nodeName != null)
            Console.WriteLine("{0}Node Name={1}, Type={2}", new string('.', lvl), nodeName, node.Type);
        else
            Console.WriteLine("{0}Node Type={1}", new string('.', lvl), node.Type);
        if (node.Type == JTokenType.Object)
        {
            foreach (JProperty child in node.Children<JProperty>())
            {
                JsonTokenDump(child.Value, lvl + 1, child.Name);
            }
        }
        else if (node.Type == JTokenType.Array)
        {
            foreach (JToken child in node.Children())
            {
                JsonTokenDump(child, lvl + 1);
            }
        }
    }
	
