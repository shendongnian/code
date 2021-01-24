    public PersonEntity(PersonDTO dto)
    {
        ID = new Identifier(dto.EY);
        Name = new Name(dto.EID);
        DOB = new DateOfBirth(dto.DOB);
        // set other non-required properties ...
    }
