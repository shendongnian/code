    static class Extensions {
     public static IEnumerable<Nodes> Flatten(this IEnumerable<Node> nodes)
     {
      foreach(var node in nodes)
      {
        yield return node;
        foreach (var child in node.Children.Flatten())
          yield return child;
      }
     }
    }
