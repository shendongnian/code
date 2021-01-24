    private async Task< bool> addUser()
        {
            
            using (libProduccionDataBase.Contexto.DataBaseContexto context = new DataBaseContexto())
            {
                using (var t = new libProduccionDataBase.Identity.ApplicationUserManager( new libProduccionDataBase.Identity.ApplicationUserStore( context ) ))
                {
                    CreatingUserModel _usr= new CreatingUserModel
                    {
                        Nombre = AddNombreKTbox.Text,
                        ApellidoPaterno = AddApPaternoKTbox.Text,
                        ApellidoMaterno = AddApMaternoKTbox.Text,
                        ClaveTrabajador = AddClaveKTbox.Text,
                        LoginName= AddLoginNameKTbox.Text,
                        Email = AddEmailKTbox.Text
                    };
                    ValidationContext validator = new ValidationContext(_usr);
                    List<ValidationResult> results = new List<ValidationResult>();
                    bool valid = Validator.TryValidateObject(_usr, validator, results, true);
                    if (valid)
                    {
                        var usr= _usr.ToApplicationUser();
                        IdentityResult result = await  t.CreateAsync(usr, AddPasswordKTbox.Text);
                        if (result.Succeeded) t.AddToRole( usr.Id, "Usuario General" );
                        
                        return result.Succeeded;
                    }else
                    {
                        StringBuilder strbld = new StringBuilder();
                        results.ForEach( err => {
                            strbld.AppendFormat( "•{0}\n", err.ErrorMessage );
                        } );
                        Console.WriteLine( strbld.ToString() );
                    }
                    return false;
                }
            }
        }
