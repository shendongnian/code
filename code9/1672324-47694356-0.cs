    var dto = new UserDto();
    dto.Email = "not an email";
    var ctx = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
    // will throw an exception if invalid
    System.ComponentModel.DataAnnotations.Validator.ValidateObject(dto, ctx, true);
