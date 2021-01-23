    {
        "EventMessageUId": "ef51b5a3-32b2-e611-baf9-fc3fdb446bd2",
    
        "Message": {
            "StoryID": 1,
            "StoryDesc": "xyzzzz"
        },
        "ProjectUId": "00100000-0000-0000-0000-000000000000",
        "ProjectId": 1,
        "CreatedByUser": "system",
        "CreatedByApp": "myWizard-Fortress",
        "CreatedOn": "2016-11-24T10:44:39.473"
    }
    public class Requirements
    {
        public string EventMessageUId { get; set; }
        public int ProjectId { get; set; }
        public string CreatedByUser { get; set; }
        public string CreatedByApp { get; set; }        
        public string CreatedOn { get; set; }
    
        private Message _Message = new Message();
        public Message Message  { get { return this._Message ; } set { this._Message = value; } }
    
    }
    public class Message
    {
       public string StoryID { get; set; }
       public string StoryDesc { get; set; }
    }
