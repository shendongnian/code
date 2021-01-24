    [TestClass]
    public class ViewBagTests {
        [TestMethod]
        public void ViewBag_ShouldBe_PrePopulated() {
            //Arrange
            var SUT = new TargetController();
            var expected = "Hey I'm the old search string :D";
            SUT.ViewData["LastSearch"] = expected;
            //Act
            var actual = SUT.Index() as ViewResult;
            //Assert
            Assert.AreEqual(expected, actual.Model);
        }
        class TargetController : Controller {
            public ActionResult Index() {
                var previous = ViewBag.LastSearch;
                return View((object)previous);
            }
        }
    }
