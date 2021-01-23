    public abstract class DocWriter : IDocListener
    {
        // ...
        // default value is true
        protected bool closeStream = true;
        public virtual bool CloseStream {
            get {
                return closeStream;
            }
            set {
                closeStream = value;
            }
        }
         protected DocWriter(Document document, Stream os)  
         {
            this.document = document;
            this.os = new OutputStreamCounter(os);
         }
         public virtual void Close() {
            open = false;
            os.Flush();
            if (closeStream) // <-- Take a look at this line
                os.Close();
         }
         // ...
    }
