        void Main()
        {
            Observable observable = new Observable();
            Observer observer = new Observer();
            observable.SomethingHappened += observer.HandleEvent;
            observable.SaveMemoryMappedFile();
        }
        class Observable
        {
            public event EventHandler SomethingHappened;
            public void SaveMemoryMappedFile()
            {
                MemoryMappedFile mmf = MemoryMappedFile.CreateNew("testmap", 10000);
                // Second process has been started and waiting for data in MMF                                          
                // Writing could be performed multiple times
                using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    writer.Write("hello world!");
                }
            }
        }
        class Observer
        {
            public void HandleEvent(object sender, EventArgs args)
            {
                // The code below should executes when writing to "testmap" file was finished. 
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("testmap"))
                {
                    using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                    {
                        BinaryReader reader = new BinaryReader(stream);
                        Console.WriteLine("Process A says: {0}", reader.ReadString());
                    }
                }
            }
        }
