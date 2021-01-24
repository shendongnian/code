    [TestMethod]
    public void TestMethod1() {
        var controller = new MyController() {
            //Inject a userId to Controller
            UserId = userId
        };
        //using json string for providing input
        var input = "{some json object here}";
        var options = JsonConvert.DeserializeObject<Employee>(input);
        var response = controller.GetEmployee(options);
    }
