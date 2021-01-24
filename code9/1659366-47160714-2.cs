    class CopyFlow : Dataflow<FileInfo, FileInfo> {
        private TransformBlock<FileInfo, FileInfo> Copier;
        private string destination;
        public CopyFlow(string destination) : base(DataflowOptions.Default) {
            this.destination = destination;
            Copier = new TransformBlock<FileInfo, FileInfo>(f => Copy(f));
            Copier.LinkTo(DataflowBlock.NullTarget<FileInfo>(), info => info == null);
            RegisterChild(Copier);
        }
        public override ITargetBlock<FileInfo> InputBlock { get { return Copier; } }
        public override ISourceBlock<FileInfo> OutputBlock { get { return Copier; } }
        protected virtual FileInfo Copy(FileInfo file) {
            try {
                return file.CopyTo(Path.Combine(destination, file.Name));
            } catch(Exception ex) {
                //Log the exception
                //Abandon this unit of work
                //resume processing subsequent units of work
                return null;
            }
        }
    }
