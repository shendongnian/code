    public class Demo2 {
        public Demo2() {
            var containers = new List<IContainer> {
                new ExternalContainer(new ExternalClass()),
                new Container()
            };
            foreach (var container in containers) {
                // query container for some components
                var components = container.Components;
                var document = components.OfType<IDocument>().FirstOrDefault(); 
                if (document != null) {
                    Console.WriteLine(document.Name);
                }
                var metadata = components.OfType<IMetadata>().FirstOrDefault();
                if (metadata != null) {
                    Console.WriteLine(metadata.Tags);
                }
            }
        }
    }
