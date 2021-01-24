    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication49
    {
        class Program
        {
           
            static void Main(string[] args)
            {
                List<FileInfo> allfiles = Directory.GetFiles(@"c:\temp").Select(x => new FileInfo(x)).ToList();
                FileList filelist = new FileList();
                Root root = new Root() { fileList = filelist };
                foreach (var file in allfiles)
                {
                    filelist.Add(new FileInfoSerializable(file));
                }
                var stream = new FileStream("c:\\temp\\Xmllist.xml", FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(Root));
                serializer.Serialize(stream, root);
            }
        }
        [Serializable]
        public class FileInfoSerializable
        {
            private readonly FileInfo _fileInfo;
            #region ~~~ Constructors ~~~
            public FileInfoSerializable() { }
            public FileInfoSerializable(FileInfo FileInfo) { _fileInfo = FileInfo; }
            #endregion
            #region ~~~ Properties ~~~
            public string Name { get { return _fileInfo.Name; } set { } }
            public string FullName { get { return _fileInfo.FullName; } set { } }
            public long Length { get { return _fileInfo.Length; } set { } }
            public string Extension { get { return _fileInfo.Extension; } set { } }
            public DateTime LastWriteTime { get { return _fileInfo.LastWriteTime; } set { } }
            public string DirectoryName { get { return _fileInfo.DirectoryName; } set { } }
            #endregion
        }
        [Serializable]
        public class Root
        {
            public FileList fileList { get; set; }
        }
        [Serializable]
        public class FileList
        {
            public List<FileInfoSerializable> filez { get; set; }
            public FileList()
            {
                filez = new List<FileInfoSerializable>();
            }
            public void Add(FileInfoSerializable m)
            {
                filez.Add(m);
            }
        }
    }
