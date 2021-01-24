    public class RoleViewModel
        {
            public int Id { get; set; }
     
            [Required]
            [Display(Name = "Role :")]
            public string RoleCode { get; set; }
     
            public IEnumerable<RoleViewModel> GetRoles()
            {
                return new List<RoleViewModel>
                                {
                                    new RoleViewModel() {Id = 1, RoleCode = "Role 1"},
                                    new RoleViewModel() {Id = 2, RoleCode = "Role 2"},
                                    new RoleViewModel() {Id = 3, RoleCode = "Role 3"}
                                };            
            }
        }
