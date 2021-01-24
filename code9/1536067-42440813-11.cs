    internal class Demo1 {
        public Demo1() {
            var documents = new List<IDocument> {
                new ExternalDocument(new ExternalClass()),
                new RichDocument()
            };
            foreach (var document in documents){
                var name = document.Name;
                Console.WriteLine(name);
                // see if it implements some interface and do something with it
                var metadata = document as IMetadata;
                if (metadata != null) {
                    Console.WriteLine(metadata.Tags);
                }
            }
        }
    }
