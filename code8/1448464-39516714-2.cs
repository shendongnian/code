    var pleaseenterapassword = "Create a password:";
                bool validPassword;
    
                //Initialize the password validator according to your needs
                var validator = new BasicPasswordPolicyValidator
                {
                    RequiredLength = 8,
                    RequireNonLetterOrDigit = true,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false
                };
    
                do
                {
                    Console.WriteLine(pleaseenterapassword); // Writes to the screen "Create a password:"
                    var password = Console.ReadLine(); //Sets the text entered in the Console into the string 'password'
    
                    var validationResult = validator.Validate(password);
                    validPassword = validationResult.Success;
                    Console.WriteLine("Your password does not comply with the policy...");
                    foreach (var error in validationResult.Errors)
                        Console.WriteLine("\tError: {0}", error);
    
                } while (!validPassword);
