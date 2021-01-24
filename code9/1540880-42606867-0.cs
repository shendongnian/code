    public class UserEntity
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int employee_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string login_id { get; set; }
        public string login_password { get; set; }
        public int role { get; set; }
        public bool is_delete { get; set; }
    	
    	public UserEntity()
    	{
    	}
    	
    	public UserEntity(UserEntity userEntity)
    	{
    		this.id = userEntity.id;
            this.employee_id = userEntity.employee_id;
            this.first_name = userEntity.first_name;
            this.email = userEntity.email;
            this.login_id = userEntity.login_id;
            this.login_password = userEntity.login_password;
            this.role = userEntity.role;
            this.is_delete = false;
    	}
    }
    
    public class UserModel : UserEntity
    {
    	public UserModel(UserEntity userEntity) : base(userEntity)
    	{
    	}
    }
