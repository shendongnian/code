    using (var reader = XmlReader.Create(@"your url", new XmlReaderSettings() {
        DtdProcessing = DtdProcessing.Ignore // or Parse
    })) {
         // get internal property which has the same function as above in XmlTextReader
         reader.GetType().GetProperty("EntityHandling", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(reader, EntityHandling.ExpandCharEntities);
         while (reader.Read()) {
              // here it will be EntityReference with no exceptions
         }
     }
