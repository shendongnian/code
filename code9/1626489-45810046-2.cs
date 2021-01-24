    public class SuccessDTO
    {
    	public int success { get; set; }
    	public string message { get; set; }
    	public List<RoleDTO> data{ get; set; }
    }
    public class RoleDTO
    {
       public string roles_name{ get; set; }
       public string description { get; set; }       
    }
    public class ErrorDTO
    {
    	public int success { get; set; }
    	public ErrorCodeDTO error { get; set; }
    }
    public class ErrorCodeDTO
    {
    	public int code { get; set; }
    	public string message { get; set; }
    }
