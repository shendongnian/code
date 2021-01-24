    Given on the <Field> I enter <Value>
    And I click the sign in button 
    Then I can validate the <ErrorMessage> is thrown for <Field>
			Examples: 
			 | Field    | Value | ErrorMessage|                                                      
			 | email    | N/A | Email is required. |                                                 
			 | password | N/A  | Password is required|  
        [Given(@"on the (.*) I enter (.*)")]
        public void GivenOnTheEmailIEnterNA(string field, string value)
        {
            switch (field.ToLower())
            {
                case "email":
                    CallYourElement.TypeEmail(value.ToLower() == "n/a" ? "" : value);
                    break;
                case "password":
                    CallYourElement.TypePassword(value.ToLower() == "n/a" ? "" : value);
                    break;
            }
        }
       [Then(@"I can validate the (.*) is thrown for (.*)")]
        public void ThenICanValidateTheEmailIsRequired_IsThrownForEmail(string expectedError, string field)
        {
            switch (field.ToLower())
            {
                case "email":
                {
                    var receivedError = CallYourElement.GetEmailRequiredError();
                     Assert.AreEqual(expectedError, receivedError);
                 }
                    break;
                case "password":
                {
                    var receivedError2 = CallYourElement.GetEmailPasswordRequiredError();
                        Assert.AreEqual(expectedError, receivedError2);
                }
                    break;
            }
        }
