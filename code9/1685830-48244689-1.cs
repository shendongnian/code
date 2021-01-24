    public class TestClass {
    
        public TestClass(){
            MonthDayModel[] arr = new MonthDayModel[10];
            arr[0] = new MonthDayModel() {
                Month = "February",
                Day = 8
            };
            arr[1] = new MonthDayModel() {
                Month = "March",
                Day = 4
            };
            //...
        }
    }
    
    public class MonthDayModel {
        public string Month { get; set; }
        public int Day { get; set; }
    }
