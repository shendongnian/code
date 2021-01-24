    internal sealed class InterProcessResource {
        private static readonly string MutexNameThisProcess = "IPR-" + Guid.NewGuid().ToString();
        private static readonly Mutex MutexThisProcess = new Mutex(true, MutexNameThisProcess);
        private readonly MemoryMappedFile mmf;
        private readonly string mutexName;
        public InterProcessResource(string resourceName) {
            this.mutexName = resourceName + "-mtx";
            this.mmf = MemoryMappedFile.CreateOrOpen(resourceName + "-mmf", 16 * 1024, MemoryMappedFileAccess.ReadWrite);
        }
        public void Acquire(Action initAction) {
            using (new Mutex(true, this.mutexName)) {
                var currentList = ReadStringList(mmf);
                if (currentList.Count == 0) {
                    initAction();
                }
                var newList = PruneMutexList(currentList);
                newList.Add(MutexNameThisProcess);
                WriteStringList(this.mmf, newList);
            }
        }
        public void Release(Action freeAction) {
            using (new Mutex(true, this.mutexName)) {
                var currentList = ReadStringList(this.mmf);
                var newList = PruneMutexList(currentList);
                WriteStringList(this.mmf, newList);
                if (newList.Count == 0) {
                    freeAction();
                }
            }
        }
        private static List<string> ReadStringList(MemoryMappedFile mmf) {
            var list = new List<string>();
            using (var stream = mmf.CreateViewStream()) {
                var reader = new BinaryReader(stream);
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++) {
                    list.Add(reader.ReadString());
                }
            }
            return list;
        }
        private static void WriteStringList(MemoryMappedFile mmf, List<string> newList) {
            using (var stream = mmf.CreateViewStream()) {
                var writer = new BinaryWriter(stream);
                int count = newList.Count;
                writer.Write(count);
                for (int i = 0; i < count; i++) {
                    writer.Write(newList[i]);
                }
            }
        }
        // removes our mutex name AND any dead processes mutex names
        private static List<string> PruneMutexList(List<string> list) {
            var newList = new List<string>();
            foreach (var s in list) {
                if (s != MutexNameThisProcess) {
                    Mutex m;
                    if (Mutex.TryOpenExisting(s, out m)) {
                        newList.Add(s);
                        m.Dispose();
                    }
                }
            }
            return newList;
        }
    }
