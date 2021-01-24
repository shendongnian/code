    Make sure these two fields are sent as part of HttpRequest from client 
    /// <summary>
        /// Number of records that should be shown in table
        /// </summary>
        public int DisplayLength { get; set; }
    
        /// <summary>
        /// First record that should be shown(used for paging)
        /// </summary>
        public int DisplayStart { get; set; }
    
    //Server side code
    GetData(){
    
                 Members.Skip(param.DisplayStart)  
                 .Take(param.DisplayLength); 
    }
