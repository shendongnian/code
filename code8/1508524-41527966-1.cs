    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Xml;
    
    namespace ConsoleApplication1
    {
    
        public class CombinedXmlStream : Stream
        {
            private Stream currentStream, startStream, endStream;
            private String[] files;
            private int currentFile = -2;
            private bool endReached = false;
    
            private static Stream ToStream(String str)
            {
                MemoryStream stream = new MemoryStream();
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(str);
                writer.Flush();
                stream.Position = 0;
                return stream;
            }
    
            public CombinedXmlStream(String start, String end, params String[] files)
            {
                this.files = files;
                startStream = ToStream(start);
                endStream = ToStream(end);
    
            }
    
            public override bool CanRead { get { return true; } }
    
            public override bool CanSeek { get { return false; } }
    
            public override bool CanWrite { get { return false; } }
    
            public override long Length { get { throw new NotImplementedException(); } }
    
            public override long Position { get { return 0; } set { } }
    
            public override void Flush() { throw new NotImplementedException(); }
    
            public override long Seek(long offset, SeekOrigin origin) { throw new NotImplementedException(); }
    
            public override void SetLength(long value) { throw new NotImplementedException(); }
    
            public override void Write(byte[] buffer, int offset, int count) { throw new NotImplementedException(); }
    
            public override int Read(byte[] buffer, int offset, int count)
            {
                doSwitching();
    
                int output = currentStream.Read(buffer, offset, count);
    
                if (output == 0)
                {
                    doSwitching(true);
                    if (currentStream != null)
                    {
                        return Read(buffer, offset, count);
                    }
                }
    
                return output;
            }
    
            private void doSwitching(bool force = false)
            {
                if (force || currentStream == null || !currentStream.CanRead)
                {
                    if (currentStream != null)
                    {
                        currentStream.Close();
                        currentStream = null;
                    }
    
                    currentFile++;
                    if (currentFile == -1)
                    {
                        currentStream = startStream;
                    }
                    else if (currentFile >= files.Length && !endReached)
                    {
                        currentStream = endStream;
                        endReached = true;
                    }
                    else if (!endReached)
                    {
                        currentStream = new FileStream(files[currentFile], FileMode.Open);
                    }
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Debug.WriteLine("Test me");
                using (XmlReader reader = XmlReader.Create(new CombinedXmlStream("<combined>", "</combined>", @"D:\test.xml", @"D:\test2.xml")))
                {
                    //reader.MoveToContent();
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            Debug.WriteLine("Node: " + reader.Name);
                        }
                    }
                }
            }
        }
    }
