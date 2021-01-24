    public class ResponseDTO
    {
    	public int success { get; set; }
    	public string message { get; set; }
    	public List<RoleDTO> data { get; set; }
    }
    public class RoleDTO
    {
       public string roles_name { get; set; }
       public string description { get; set; }       
    }
