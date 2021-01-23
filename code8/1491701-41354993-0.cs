     public void OnResultExecuting_Test()
     {
         // Arrange sesction :
         var httpContextWrapper = new Moq<HttpContextBase>();
         var genericIdentity = new GenericIdentity("FakeUser","AuthType");
         var genericPrincipal = new GenericPrincipal(genericIdentity , new string[]{"FakeRole"});
         httpContextWrapper.Setup(o=> o.User).Return(genericPrincipal);
         var controller = new FakeController(); // you can define a fake controller class in your test class (should inherit from MVC Controller class)
         controller.controllerContext = new ControllerContext( httpContextWrapper.Object, new RouteData(), controller );
         var audit = new Moq<IUnitOfWork>();
         var uow = new Moq<IAuditService>();
         // more code here to do assertion on audit
         uow.Setup(o=>o.SaveChanges()).Verifiable();
         var attribute= new AuditAttribute(audit.Object,uow.Object);
    
         // Act Section:
         attribute.OnActionExecuting( filterContext );
    
         // Assert Section:
         ... // some assertions
         uow.Verify();
         
     }
