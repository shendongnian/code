    public class CreatingUserModel
    {
        [Required(ErrorMessage ="El nombre para inicio de sesion es Requerido")]
        [MinLength(6, ErrorMessage ="El Nombre para inicio de sesion debe contener al menos 6 caracteres")]
        public string LoginName { get; set; }
        [Required( ErrorMessage = "El Nombre del usuario es requerido" )]
        public string Nombre { get; set; }
        [Required( ErrorMessage = "El Apellido Paterno del usuario es requerido" )]
        public string ApellidoPaterno { get; set; }
        [Required( ErrorMessage = "El Apellido Materno del usuario es requerido" )]
        public string ApellidoMaterno { get; set; }
        [MaxLength( 10, ErrorMessage = "El largo maximo para la clave del trabajador es de 10 caracteres" )]
        public string ClaveTrabajador { get; set; }
        [Required(ErrorMessage ="El Email es requerido")]
        [EmailAddress(ErrorMessage ="No es un email Valido")]
        public string Email { get; set; }
        [Required( ErrorMessage = "La contraseña es requerida" )]
        [MinLength( 6, ErrorMessage = "La contraseña debe ser de al menos 6 caracteres" )]
        public string Contraseña { get; set; }
        [Required( ErrorMessage = "La confirmacion de la contraseña es requerida" )]
        [Compare(nameof(Contraseña), ErrorMessage ="La contraseña confirmada no coincide")]
        public string ConfirmeContraseña { get; set; }
        public ApplicationUser ToApplicationUser()
        {
            return new ApplicationUser
            {
                Nombre = this.Nombre,
                ApellidoPaterno = this.ApellidoPaterno,
                ApellidoMaterno = this.ApellidoMaterno,
                ClaveTrabajador = this.ClaveTrabajador,
                UserName = this.LoginName,
                Email = this.Email
            };
                        
        }
    }
