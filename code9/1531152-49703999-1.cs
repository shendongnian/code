    [HttpPost]
    public IApiResponse Update([FromBody] User user) {
        if (user == null) return new ApiBadRequestResponse(ModelState);
        return _userService.Post(user) ? new ApiOkResponse(user) : new ApiResponse(500);
    }
