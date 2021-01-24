    public partial class TestDTO : ITestDTO
    {
        [DataMember(Name = "DeleteMeEnum")]
        private string DeleteMeEnumString 
        {
             get { return DeleteMeEnum.ToString(); }
             set {
                  DeleteMe _enum;
                  if (!Enum.TryParse(value, out _enum))
                  {
                      _enum = <default value>;
                  }
                  DeleteMeEnum = _enum;
             }
        }   
    
        [IgnoreDataMember]
        public DeleteMe DeleteMeEnum { get; set; }
    }
