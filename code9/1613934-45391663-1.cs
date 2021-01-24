    [Test]
    public void New_GUID_should_be_added_when_OnActionExecuting_is_executing()
    {
        //arrange section:
        const string REQUEST_GUID_FIELD_NAME = "RequestGUID";
        var owinContext = MockRepository.GenerateStub<IOwinContext>();
        var target = MockRepository.GeneratePartialMock<MyCustonAttributte>();
        target.Stub(x => x.GetOwinContext())
            .Return(owinContext);
        //act:
        target.OnActionExecuting(new HttpActionContext());
        //assert section:
        owinContext.AssertWasCalled(x => x.Set(Arg<string>.Is.Equal(REQUEST_GUID_FIELD_NAME),
            Arg<Guid>.Is.NotEqual(Guid.Empty)));
    }
