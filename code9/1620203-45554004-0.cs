    //Matches GET ~/people/phone/123456789
    //Matches GET ~/people/email/someone@example.com
    //Matches GET ~/people/name/John Doe  
    [HttpGet, Route("people/{searchByType:regex(^phone|email|name$)}/{filter}")]
    [NoNullArguments]
    [Filterable]
    public IHttpActionResult FindPeople(string searchByType, string filter) {
        var response = new List<SearchSummary>();
        switch (searchByType.ToLower()) {
            case "phone":
                response = peopleFinder.FindPeopleByPhone(filter);
                break;
            case "email":
                response = peopleFinder.FindPeopleByEmail(filter);
                break;
            case "name":
                response = peopleFinder.FindPeopleByName(filter);
                break;
            default:
                return BadRequest();
        }
        return Ok(response);
    }
