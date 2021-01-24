    public class Btn1
    {
        public string Caption { get; set; }
    }
    public class Btn2
    {
        public string Caption { get; set; }
    }
    public class Activity
    {
        public Btn1 btn1 { get; set; }
        public Btn2 btn2 { get; set; }
    }
    public class BtnA
    {
        public string Caption { get; set; }
    }
    public class BtnB
    {
        public string Caption { get; set; }
    }
    public class Navigate
    {
        public BtnA btnA { get; set; }
        public BtnB btnB { get; set; }
    }
    public class BtnX1
    {
        public string Caption { get; set; }
    }
    public class BtnX2
    {
        public string Caption { get; set; }
    }
    public class Print
    {
        public BtnX1 btnX1 { get; set; }
        public BtnX2 btnX2 { get; set; }
    }
    public class Buttons
    {
        public Activity Activity { get; set; }
        public Navigate Navigate { get; set; }
        public Print Print { get; set; }
    }
    public class RootObject
    {
        public Buttons Buttons { get; set; }
    }
