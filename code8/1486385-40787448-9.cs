       // create the Xsl Transformation
       var xct = new XslCompiledTransform();
       // use any another Stream if needed
       // xsl holds the XSLT stylesheet
       xct.Load(XmlReader.Create(new StringReader(xsl)));
       Root result;
       // we stream the result in memory
       using(var ms = new MemoryStream())
       {
          // write it
          using(var xw = XmlWriter.Create(ms))
          {
             // transform input XML  
             // the string xml holds the test XML input, replace with a stream
             xct.Transform(XmlReader.Create(new StringReader(xml)), xw);
          }
          Encoding.UTF8.GetString(ms.ToArray()).Dump(); // linqpad testing
          // now we're ready to deserialize
          var xs = new XmlSerializer(typeof(Root));
          ms.Position = 0;
          result= (Root) xs.Deserialize(ms);
          result.Dump(); // Linqpad testing
       }
