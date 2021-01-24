    public class  CreateUserVm
    {
       public int Id { set;get;}
    
       [Required(ErrorMessage = "Email is required")]
       [UniqueEmail]
       public string Email { set;get;}
    
       public string Name { set;get; }
    }
