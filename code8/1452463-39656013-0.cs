    [DataContract] 
    [KnownType( typeof( Student ) )]
    [KnownType( typeof(Teacher) )]
    public abstract class BaseService
    	{
    		[DataMember]
    		public int Code { get; set; }
     
    		[DataMember]
    		public string Name { get; set; }
    	}
    [DataContract]  
    public class Student : BaseService
    	{
    		[DataMember]
    		public int StudentId { get; set; }
    	}
    [DataContract]
    public class Teacher : BaseService
    	{
    		[DataMember]
    		public int TeacherId { get; set; }
    	} 
