    _mock
        .Setup(a => a.AddIpApplication(It.IsAny<IpApplication>()))
        .Callback((IpApplication arg) => { //<-- use call back to modify the provided parameter
            arg.Code = new Guid("9631E691-B935-4E12-9037-2E874DB15B0D");
            arg.Description = "Test application";
            arg.Enabled = true;
            arg.Name = "APPLICATION_ZERO";
        })
        .Returns((IpApplication arg) => arg); //<-- return provided parameter after Callback
