    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyUnitTestApplication;
    using MyUnitTestApplication.Controllers;
    using MyUnitTestApplication.Models;
    using Moq;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Routing;
    //using Rhino.Moq;
    using Rhino.Mocks;
    
        
     namespace MyUnitTestApplication.Tests.Controllers
        {
            [TestClass]
            public class HomeControllerTest
            {
                [TestMethod]
                public void TestActionMethod()
                {
                    Employee User = new Employee();
                    User.FirstName = "Ali";
                    User.EmployeeId = 1;
                    SessionManager.CurrentUser = User;
         var fakeHttpContext = new Mock<HttpContextBase>();
          var sessionMock = new Mock<HttpSessionStateBase>();
                    sessionMock.Setup(n => n["UserType"]).Returns("ADMIN");
                    sessionMock.Setup(n => n.SessionID).Returns("1");
         fakeHttpContext.Setup(n => n.Session).Returns(sessionMock.Object);
         var sut = new HomeController();
                    sut.ControllerContext = new ControllerContext(fakeHttpContext.Object, new RouteData(), sut);
                    ViewResult result = sut.TestMe() as ViewResult;
                    Assert.AreEqual(string.Empty, result.ViewName);
        }
        }
        }
