    // 200
    actionResult.Should().BeOfType<OkObjectResult>()
        .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
    // 201
    actionResult.Should().BeOfType<CreatedResult>()
	    .Which.StatusCode.Should().Be((int)HttpStatusCode.Created);
    // 500
	actionResult.Should().BeOfType<ObjectResult>()
		.Which.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
