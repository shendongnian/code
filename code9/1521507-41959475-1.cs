    public ICommand EnumerationValueChangedCommand
    {
        get
        {
            return new Command(
                () =>
                    {
                        if (VM.MySelectionIsAnEnumeration == Values.Baz)
                        {
                            //Prompt the user and get DialogResult.
                            bool answerGiven = AskAQuestionAndGetAResult();
                            if (!answerGiven)
                                VM.MySelectionIsAnEnumeration = Values.Foo;
                        }
                    });
        }
    }
