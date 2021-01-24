           static void Main(string[] args)
        {
            // here I am using first takes  a valid connectionstring  from encrypt it.
            // this is needed because I am showing it in console application idealy this step is independent of this 
            // this needs to be done by some build and deployment tool which wil copy this encrypted string to app.config 
            var encryptString = Encrypt.EncryptString("Data Source=yashssd;Initial Catalog=StackOverFlow1;Integrated Security=True", "myKey");
            // this encryped connecton string I will save to th app.config manauly but this can be auutomated with build/ deployment tools
            //var decrypt = Encrypt.DecryptString(encryptString, "myKey");
            using (var ctx = new TestContext("EncryptedConnection"))
            {
                // for testing to see al working 
                //this is important to read the entity first .
                var contact = ctx.Contacts.FirstOrDefault(x => x.ContactID == 1);
            }
            Console.ReadLine();
        }
