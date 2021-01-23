            public class User
            {
                /// <summary>
                /// Gets or Sets Usertype.
                /// </summary>
                public string UserType { get; set; }
                /// <summary>
                /// Gets or Sets KurumKodu.
                /// Here "Usertype" is property. In that you have to assign current user's role.
                /// "user" is constant role. If  "UserType" has value as "user" then this will be required.
                /// </summary>
                [RequiredIf("UserType", "user", ErrorMessage = "It is required")]
                public decimal KurumKodu { get; set; }
            }
