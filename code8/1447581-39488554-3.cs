    public enum ErrorLevel
    {
        Error,
        Warning,
        Information
    }
---
    public class MyObject
    {
        public string Title { get; set; }
        public ErrorLevel ErrorLevel { get; set; }
    }
