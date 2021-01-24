     [Bind(Include = "FirstName,MiddleName,LastName,Position,TruckTypeID,Direction,Organization,Objective,TimeStart,TimeEnd")]
        public partial class UserRequestRegisterModel
        {
            [DisplayName("Имя")]
            [Required]
            public string FirstName { get; set; }
    
            [DisplayName("Фамилия")]
            [Required]
            public string MiddleName { get; set; }
    
            [DisplayName("Отчество")]
            [Required]
            public string LastName { get; set; }
    
            [DisplayName("Должность")]
            [Required]
            public string Position { get; set; }
    
            [DisplayName("Тип транспорта")]
            [Required]
            public System.Guid TruckTypeID { get; set; }
    
            [DisplayName("Направление")]
            [Required]
            public string Direction { get; set; }
    
            [DisplayName("Организация")]
            [Required]
            public string Organization { get; set; }
    
            [DisplayName("Цель")]
            [Required]
            public string Objective { get; set; }
    
            [DisplayName("Время убытия")]
            [Required]
            // [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy  HH:mm}", ApplyFormatInEditMode = true)]
            public System.DateTime TimeStart { get; set; }
    
            [DisplayName("Время прибытия")]
            [Required]
            // [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
            public Nullable<System.DateTime> TimeEnd { get; set; }        
        }
    
    
    public partial class RequestUserModel
        {
            public List<UserRequestViewItem> UserRequestViewItems { get; set; }
            public UserRequestRegisterModel UserRequest { get; set; }
    
            public RequestUserModel()
            {
                UserRequestViewItems = new List<UserRequestViewItem>();
                UserRequest = new UserRequestRegisterModel();
            }
        }
