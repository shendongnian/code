    public int RowId { 
        public get {
            return this.Type.equals("news") ? NewsId.Value : ItemId.Value;
        };   
        private set {
            if(this.Type.equals("news")){
              NewsId = value;
            }
            else{
              ItemId = value;
            }
        }
    }
