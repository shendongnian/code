    public class UserModel
    {
        public Guid Id { get; set; }
    
        [Display(Name = "Your name")]
        public string FirstName { get; set; }
    
        [Display(Name = "Lastname")]
        public string Surname { get; set; }
    
        [Display(Name = "E-mail address")]
        public string EmailAddress { get; set; }
    
        [Display(Name = "Username")]
        public string UserName { get; set; }
    
        [Display(Name = "Active")]
        public bool Active { get; set; }
    
        [Display(Name = "Active")]
        public string ActiveAsText => Active ? "Active" : "Inactive";
    }
_______________________
    <table>
      <tr>
        <th>@Model.FirstName</th>
        <th>@Model.Surname</th> 
        <th>@Model.EmailAddress</th>
        ...
      </tr>
      ...
    </table>
