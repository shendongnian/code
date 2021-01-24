              public void DisplayStudent()
              {
                 HomeController obj = new HomeController();
                 ViewResult result = obj.Index() as ViewResult;
                 Assert.AreEqual("Index", result.ViewName);
                Student stud = (Student)result.ViewData.Model;
                Assert.AreEqual("Sachin", stud.StudentName);
              }
