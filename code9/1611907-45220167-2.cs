    [HttpPut]
    [Route("updatecasepersonal/{Caseid}/{Title}/{Forename}/{Surname}/{Email}/{Telephone}/{Mobile}")]
    public string UpdateCasePersonal(string Caseid, string Title, string Forename, string Surname, string Telephone, string Email, string Mobile)
    {
        ...
    }
