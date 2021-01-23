    public abstract class HttpPostedFileBase {
    
            public virtual int ContentLength {
                get {
                    throw new NotImplementedException();
                }
            }
    
            public virtual string ContentType {
                get {
                    throw new NotImplementedException();
                }
            }
    
            public virtual string FileName {
                get {
                    throw new NotImplementedException();
                }
            }
    
            public virtual Stream InputStream {
                get {
                    throw new NotImplementedException();
                }
            }
    
            [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "filename",
                Justification = "Matches HttpPostedFile class")]
            public virtual void SaveAs(string filename) {
                throw new NotImplementedException();
            }
    
        }
