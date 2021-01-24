      var output = new StringBuilder();
      foreach (XmlNode customer in workUnit)
      {
          // search for value for first column (EmployeeID)
          var node = workUnit.SelectSingleNode("tlp:EmployeeID");
          if (node != null)
          {
             output.Append(node.InnerText).Append(',');
          }
          else
          {
             output.Append(','); // no content, but we still need a separator
          }
          // etc for the other columns
