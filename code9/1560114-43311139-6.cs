    class AddCommand : PersonCommand
    {
        AddCommand(Person person) : base(person) { }
        public override void Apply()
        {
            // send REST PUT request, add person to DB, whatever you want to do here.
        }
    }
    class UpdateCommand : PersonCommand
    {
        UpdateCommand(Person person) : base(person) { }
        public override void Apply()
        {
            // send REST POST request, update person in DB, whatever you want to do here.
        }
    }
    class DeleteCommand : PersonCommand
    {
        DeleteCommand(Person person) : base(person) { }
        public override void Apply()
        {
            // send REST DELETE request, remove person from DB, whatever you want to do here.
        }
    }
