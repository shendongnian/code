    public class MessageModel
    {
        public string Name{get;set;}
        public BindingList<AttachDocument> AttachDocuments {get;set;}
    }
    foreach (AttachDocument s in source.AttachDocuments)
    {
        AttachDocument t = new AttachDocument();
        t.AttachName = s.AttachName;
        value.AttachDocuments.Add(t);
    }
