    var list = await collection.Find(filt).ToListAsync();
                for (int ii=0; ii<list.Count; ii++)
                {
                    Console.WriteLine("Battery " + list[ii].Battery);
                }
