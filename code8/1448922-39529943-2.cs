    Then("I get a message indicating that the contract has been saved")
    public void ThenIGetAMessage()
    {    
        //pseudo code
        Regex regex = new Regex("The contract [0-9a-zA-Z]+ has been successfully saved"
        regex.Match(result).Should().BeTrue();
    }
