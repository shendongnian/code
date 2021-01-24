      var output = new StringBuilder();
      foreach (XmlNode customer in workUnit)
      {
          var node = workUnit.SelectSingleNode("tlp:EmployeeID");
          if (node != null)
          {
             output.Append(node.InnerText).Append(',');
          }
          else
          {
             output.Append(','); // no content, just separator
          }
          // etc
