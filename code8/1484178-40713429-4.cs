    //Your Master Model Properties 
        public partial class YourMasterModel
            {
                 public List<YourModel> YourMasterModelList{ get; set;  }
                 public YourModel YourModel{ get; set; }
             }    
       //Your Model Properties 
        public partial class YourModel
            {
                public int Id { get; set; }
                public string Param1 { get; set; }
                public string Param2 { get; set; }
                public int[] SelectedListOptions { get; set; }
            }
