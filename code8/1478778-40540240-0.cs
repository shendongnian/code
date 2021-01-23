      //string uaString = "Mozilla/5.0 (iPhone; CPU iPhone OS 5_1_1 like Mac OS X) AppleWebKit/534.46 (KHTML, like Gecko) Version/5.1 Mobile/9B206 Safari/7534.48.3";
      
     // Request the header
      string uaString= HttpContext.Current.Request.UserAgent.ToString();
      
    // get a parser with the embedded regex patterns
      var uaParser = Parser.GetDefault();
      // get a parser using externally supplied yaml definitions
      // var uaParser = Parser.FromYamlFile(pathToYamlFile);
      // var uaParser = Parser.FromYaml(yamlString);
      ClientInfo c = uaParser.Parse(uaString);
      Console.WriteLine(c.UserAgent.Family); // => "Mobile Safari"
      Console.WriteLine(c.UserAgent.Major);  // => "5"
      Console.WriteLine(c.UserAgent.Minor);  // => "1"
      Console.WriteLine(c.OS.Family);        // => "iOS"
      Console.WriteLine(c.OS.Major);         // => "5"
      Console.WriteLine(c.OS.Minor);         // => "1"
      Console.WriteLine(c.Device.Family);    // => "iPhone"
