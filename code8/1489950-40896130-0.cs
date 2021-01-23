    namespace CSharpConsoleApplication.Tests
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
    
        class TemporaryTest
        {
            public static void Run()
            {
                Mother<FirstCompanyEvent> firstChild = new FirstChild(new FirstCompanyEvent("this is wrong"));
                firstChild.Print();
    
    
                Mother<SecondCompanyEvent> intChild = new SecondChild(new SecondCompanyEvent("you are too young to do this"));
                intChild.Print();
            }
        }
    
    
        public abstract class BaseCompanyEvent
        {
            protected string Value { get; private set; }
    
            public BaseCompanyEvent(string value)
            {
                Value = value;
            }
    
            public abstract string GetMessage();
        }
    
        public class FirstCompanyEvent : BaseCompanyEvent
        {
            public FirstCompanyEvent(string value)
                : base(value)
            { }
    
            public override string GetMessage()
            {
                return "First born: " + Value;
            }
        }
    
        public class SecondCompanyEvent : BaseCompanyEvent
        {
            public SecondCompanyEvent(string value)
                : base(value)
            { }
    
            public override string GetMessage()
            {
                return "Younger brother: " + Value;
            }
        }
    
    
    
        public abstract class Mother<T> where T : BaseCompanyEvent
        {
            protected T CustomEvent { get; private set; }
    
            public Mother(T customEvent)
            {
                CustomEvent = customEvent;
            }
    
            public abstract void Print();
        }
    
        public class FirstChild : Mother<FirstCompanyEvent>
        {
            public FirstChild(FirstCompanyEvent e)
                : base(e)
            { }
    
            public override void Print()
            {
                Console.WriteLine(CustomEvent.GetMessage());
            }
        }
    
        public class SecondChild : Mother<SecondCompanyEvent>
        {
            public SecondChild(SecondCompanyEvent e)
                : base(e)
            { }
    
            public override void Print()
            {
                Console.WriteLine(CustomEvent.GetMessage());
            }
        }
    }
