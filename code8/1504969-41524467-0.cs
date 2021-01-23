            public static void BlobIBinder(
                [QueueTrigger("persons")] Person persons, 
                IBinder binder)
            {
                var blobAttrib = new BlobAttribute("persons/" + persons.Name + "BlobIBinder");
                var writer = binder.Bind<TextWriter>(blobAttrib);
                writer.Write("Hello " + persons.Name);
        }
