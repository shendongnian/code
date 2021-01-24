    public void CreateUser(string username, string firstName, string lastName, string email, string phoneNumber)
        {
                WWWForm form = new WWWForm();
                form.AddField("userNamePost", username);
                form.AddField("firstNamePost", firstName);
                form.AddField("lastNamePost", lastName);
                form.AddField("phoneNumberPost", phoneNumber);
                form.AddField("emailPost", email);
                WWW www = new WWW("URL of the PHP file", form);
        }
