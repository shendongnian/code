    namespace Example
    {
        using System;
        using System.IO;
        using System.Text;
        using System.Security.Cryptography;
    
        public static class TextEx
        {
            public static void ChangeEncoding(string srcFile, Encoding encoding)
            {
                if (srcFile == null)
                    throw new ArgumentNullException(nameof(srcFile));
                if (encoding == null)
                    throw new ArgumentNullException(nameof(encoding));
                if (!File.Exists(srcFile))
                    throw new FileNotFoundException();
    
                // get the current encoding of the source file and cancel if it equals
                // with the specified encoding
                if (encoding.Equals(GetEncoding(srcFile)))
                    return;
    
                // creates the destination file on the same location to be sure we
                // have rights to write there
                var newFile = string.Concat(srcFile, ".new");
                File.Create(newFile).Close();
    
                // read the source file and write to the destination file
                using (var sr = new StreamReader(srcFile))
                {
                    var ca = new char[4096];
                    using (var sw = new StreamWriter(newFile, true, encoding))
                    {
                        int i;
                        while ((i = sr.Read(ca, 0, ca.Length)) > 0)
                            sw.Write(ca, 0, i);
                    }
                }
    
                // generate the hashcode of the source file for comparison
                var srcHash = GetFileHash(srcFile);
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
                File.Delete(srcFile);
                File.Move(newFile, srcFile);
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
