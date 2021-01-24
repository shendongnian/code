                    for (int i = 1; i > 0; i++)
                    {
                         try
                         {
                             File.Move(sourceFileName, destinationFileName);
                             break;
                         } catch
                         {
                             GC.Collect();
                         }
                    }
