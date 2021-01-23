              tasks.AsParallel().ForAll(x =>
                {
                    Console.WriteLine("Starting " + x.Item1);
                    x.Item2();
                });
