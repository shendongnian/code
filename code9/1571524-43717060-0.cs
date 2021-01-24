    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
        void Serialize(string path, KillEvent ev)
        {
            FileStream fs = new FileStream(path, FileAccess.ReadWrite, FileMode.OpenOrCreate, FileShare.None);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, ev);
        }
