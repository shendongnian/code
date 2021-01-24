    [HttpGet]
    public ActionResult MarriageByPersonId([FromForm]int id)
    {
        var person = _personRepository.GetById(id);
        var marriage = _marriageRepository.GetById(person.marriage_id);
        return Marriage(marriage);
    }
