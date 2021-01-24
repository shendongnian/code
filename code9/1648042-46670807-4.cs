    class EmailInfo 
    { 
        public string Data{get;set;}
        public string Attachement{get;set;}
    }
       
    var readerBlock = new TransformManyBlock<string,EmailInfo>(path=>infosFromXml(path));
    var mailBlock = new ActionBlock<EmailInfo>(info=>sendMailFromInfo(info));
   
    readerBlock.LinkTo(mailBlock,new DataflowLinkOptions{PropagateCompletion=true});
