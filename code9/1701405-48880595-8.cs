      // Initial and target file
      string FilePath = Path.Combine(strFullProcessedPath, strFileName); 
      // Temporary file 
      string tempFile = Path.ChangeExtension(FilePath, ".~temp");        
      char[] buffer = new char[2000];
      using (StreamReader reader = new StreamReader(FilePath)) {
        bool first = true;
        using (StreamWriter writer = new StreamWriter(tempFile)) {
          while (true) {
            int size = reader.ReadBlock(buffer, 0, buffer.Length);
            if (size > 0) {  // Do we have anything to write?
              if (!first) // Are we in the middle and have to add a new line?
                writer.WriteLine();
              for (int i = 0; i < size; ++i)
                writer.Write(buffer[i]);
            }
            // The last (incomplete) chunk
            if (size < buffer.Length)
              break;
            first = false;
          }
        }
      }
      File.Delete(FilePath);
      // Move temporary file into target one
      File.Move(tempFile, FilePath);
      // And finally removing temporary file 
      File.Delete(tempFile);
