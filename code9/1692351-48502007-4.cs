    //Matches GET api/permission/1234/98766
    [HttpGet("{idUser:int}/{idPermission:int}", Name = "GetUserPermissionByID")]
    public async Task<IActionResult> GetUserPermissionByID([FromQuery]int idUser, [FromQuery]int idPermission) {
        //...code removed for brevity
    }
