    class RegistrationModel
    {
        public string FirstName {get;set;} // etc.. etc...
    }
    var myJson = JsonConvert.SerializeObject(new RegistrationModel { FirstName = "Bob" });
