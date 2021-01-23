     static void Main(string[] args)
            {
                FILE test1233;
                test1233 = new FILE(); // <---- Ex is not thrown here!?                           test1233.fileName = "";
                test1233.folderName = "";
                test1233.fileHashDigest = new byte[1];
            }
    public class FILE
        {
            private string _fileName;
            public string fileName
            {
    
                get
                {
                    if (YOUR SETTING CONDITION HERE)
                        return this._fileName.ToUpper();
                    else
                        return this._fileName;
                }
                set
                {
                    if (YOUR SETTING CONDITION HERE)
                        this._fileName = value.ToUpper();
                    else
                        this._fileName = value;
                }
            }
            public string folderName { get; set; }
            public byte[] fileHashDigest { get; set; }
        }
