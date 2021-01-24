    namespace Example
    {
        using System;
        using System.IO;
        using System.Text;
        using System.Security.Cryptography;
    
        public static class TextEx
        {
            public static void ChangeEncoding(string file, Encoding encoding)
            {
                if (file == null)
                    throw new ArgumentNullException(nameof(file));
                if (encoding == null)
                    throw new ArgumentNullException(nameof(encoding));
                if (!File.Exists(file))
                    throw new FileNotFoundException();
    
                // get the current encoding of the source file and cancel if it equals
                // with the specified encoding
                if (encoding.Equals(GetEncoding(file)))
                    return;
    
                // creates the destination file on the same location to be sure we
                // have rights to write there
                var newFile = string.Concat(file, ".new");
                File.Create(newFile).Close();
    
                // read the source file and write to the destination file
                using (var sr = new StreamReader(file))
                    using (var sw = new StreamWriter(newFile, true, encoding))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                            sw.WriteLine(line);
                    }
    
                // generate the hashcode of the source file for comparison
                var srcHash = GetFileHash(file);
                // generate the hashcode of the finished destination file and compare
                // it with the hashcode of the source file
                var newHash = GetFileHash(newFile);
                if (srcHash.Equals(newHash))
                {
                    // delete the destination file if there are no changes inside
                    File.Delete(newFile);
                    return;
                }
    
                // overwrite the file if it is different
                File.Delete(file);
                File.Move(newFile, file);
            }
    
            public static Encoding GetEncoding(string file)
            {
                if (string.IsNullOrEmpty(file))
                    throw new ArgumentNullException(nameof(file));
                if (!File.Exists(file))
                    throw new FileNotFoundException();
                Encoding encoding;
                using (var sr = new StreamReader(file, true))
                {
                    sr.Peek();
                    encoding = sr.CurrentEncoding;
                }
                return encoding;
            }
    
            public static string GetFileHash(string file)
            {
                if (string.IsNullOrEmpty(file))
                    throw new ArgumentNullException(nameof(file));
                if (!File.Exists(file))
                    throw new FileNotFoundException();
                string hash;
                using (var md5 = MD5.Create())
                    using (var fs = File.OpenRead(file))
                    {
                        var bytes = md5.ComputeHash(fs);
                        hash = BitConverter.ToString(bytes);
                    }
                return hash;
            }
        }
    }
