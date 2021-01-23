    Then("the message "(.*)" is displayed")
    public void ThenIGetAMessage(string regex)
    {    
        //pseudo code
        Regex regex = new Regex(regex.Replace("<ContractNumber>","[0-9a-zA-Z]+"));
        regex.Match(result).Should().BeTrue();
    }
