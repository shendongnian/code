    class MyClass : IComparable<MyClass> {
        public static SortedSet<MyClass> Instances = new SortedSet<MyClass>();
        private static object sync = new object();
        private int idUnique;
        private int originalIdUnique;
        public MyClass() {
            lock (sync) {
                idUnique = Instances.Count > 0 ? Instances.Max.idUnique + 1 : 1;
                originalIdUnique = idUnique;
                Instances.Add(this);
            }
        }
        // It could be a Dispose()!
        public void Delete() {
            if (idUnique == int.MinValue) {
                return;
            }
            lock (sync) {
                Instances.Remove(this);
                if (Instances.Count > 0 && this.idUnique < Instances.Max.idUnique) {
                    var instances = Instances.GetViewBetween(this, Instances.Max);
                    foreach (var instance in instances) {
                        instance.idUnique--;
                    }
                }
                idUnique = int.MinValue;
            }
        }
        public override string ToString() {
            return string.Format("Id: {0} (OriginalId: {1})", idUnique, originalIdUnique);
        }
        #region IComparable<MyClass> Members
        public int CompareTo(MyClass other) {
            return idUnique.CompareTo(other.idUnique);
        }
        #endregion
    }
