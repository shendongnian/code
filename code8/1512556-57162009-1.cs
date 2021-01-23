    public void IndexTest()
        {
            // arrange
            MockContext mockContext = new MockContext();
            #region creating cookie
            HttpCookie cookie = new HttpCookie(Constant.COOKIE_ADMIN_USER_INFO,
                                             Config.DefaultCountryID.ToString());
            cookie.Values.Add(Constant.COOKIE_ADMIN_VALUE_COUNTRY_ID,
                              Config.DefaultCountryID.ToString());
            cookie.Values.Add(Constant.COOKIE_ADMIN_VALUE_LANGUAGE_ID,
                              Config.DefaultLanguageID.ToString());
            mockContext.Cookies.Add(cookie);
            #endregion
            #region Creating controller
            ControllerContext controllerContex = new ControllerContext()
            {
                HttpContext = mockContext.Http.Object
            };
            HomeController controller = new HomeController()
            {
                ControllerContext = controllerContex
            };
            #endregion
            // act
            var output = (ViewResult)controller.Index();
            var result = output.ViewData;
            // assert
            result.ShouldNotBeNull();
        }
