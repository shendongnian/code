    public class SomeModel {
        List<KeyValuePair<int, String>> SomeList { get; set; }
    }
    
    [HttpGet]
    SomeControllerMethod() {
        SomeModel someModel = new SomeModel();
        someModel.SomeList = GetListSortedAlphabetically();
        return this.Json(someModel, JsonBehavior.AllowGet);
    }
