    class NodeComparer : IEqualityComparer<XmlNode>
    {
      public bool Equals(XmlNode x, XmlNode y)
      {
        if (x == null || y == null)
          return false;
        if (x.ChildNodes.Count != y.ChildNodes.Count)
          return false;
        var nodeNames = new [] { "name", "kind", "url" };
        for (int i = 0; i < x.ChildNodes.Count; i++)
        {
          foreach (var nodeName in nodeNames)
          {
            if (!x[nodeName].InnerText.Equals(y[nodeName].InnerText))
              return false;
          }
        }
        // TODO some testing of attributes
        return true;
      }
      public int GetHashCode(XmlNode obj)
      {
        return 1;
      }
    }
    static void Main(string[] args)
    {
      XmlDocument xdocA = new XmlDocument();
      xdocA.Load(pathA);
      XmlDocument xdocB = new XmlDocument();
      xdocB.Load(pathB);
      var nodesA = xdocA.SelectNodes("Root/value").Cast<XmlNode>();
      var nodesB = xdocB.SelectNodes("Root/value").Cast<XmlNode>();
                                                                  
      var comp = new NodeComparer();
      var errors = nodesA.Where(na => !nodesB.Contains(na, comp));
      if (errors.Count() > 0)
      {
        Console.WriteLine("ERRORS: ");
        foreach (var error in errors)
        {
          Console.WriteLine(string.Join(", ", error.Cast<XmlNode>().Select(xn => $"{xn.Name}: {xn.InnerText}")));
          Console.WriteLine();
        }
      }
      else
      {
        Console.WriteLine("No Errors");
      }
      Console.ReadLine();
    }
  
    }
