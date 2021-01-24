            ConcurrentQueue<string> filesToConvert = new ConcurrentQueue<string>();
            foreach(string file in Directory.GetFiles("C:", "*.mkv"))
            {
                filesToConvert.Enqueue(file);
            }
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                new Task(async () =>
                {
                    while(true)
                    {
                        if(filesToConvert.TryDequeue(out string path))
                        {
                            await new Conversion().SetInput(path)
                                            .UseMultiThread(false)
                                            .SetOutput(Path.GetRandomFileName())
                                            .Start();
                        }
                    }
                });
            }
