    	IAuthenticationService authenticationService = Substitute.For<IAuthenticationService>();
 
			authenticationService
			    .SignInAsync(Arg.Any<HttpContext>(), Arg.Any<string>(), Arg.Any<ClaimsPrincipal>(),
				    Arg.Any<AuthenticationProperties>()).Returns(Task.FromResult((object) null));
					
			var serviceProvider = Substitute.For<IServiceProvider>();
		    var authSchemaProvider = Substitute.For<IAuthenticationSchemeProvider>();
		    var systemClock = Substitute.For<ISystemClock>();
		  
		    authSchemaProvider.GetDefaultAuthenticateSchemeAsync().Returns(Task.FromResult
			(new AuthenticationScheme("idp", "idp", 
			    typeof(IAuthenticationHandler))));
			serviceProvider.GetService(typeof(IAuthenticationService)).Returns(authenticationService);
		    serviceProvider.GetService(typeof(ISystemClock)).Returns(systemClock);
		    serviceProvider.GetService(typeof(IAuthenticationSchemeProvider)).Returns(authSchemaProvider);
			context.RequestServices.Returns(serviceProvider);
			
			
			// Your act goes here
			
			// Your assert goes here
