        [Given(@"a user has registered with the following information")]
        public void GivenAUserHasRegisteredWithTheFollowingInformation(Table table)
        {
            GivenIHaveFilledOutTheRegistrationFormAsFollows(table);
            WhenISubmitTheRegistration();
            ThenTheResponseCodeShouldBe(200)
        }
