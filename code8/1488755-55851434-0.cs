    using System;
    
    namespace AnonymousInnerClassExample
    {
        class Program
        {
            public static void Main(string[] args)
            {
                Button button = Button.CreateFromDynamic(new
                {
                    OnClick = new Action(() =>
                    {
                        Console.WriteLine("Hit OnClick");
                    })
                });
                button.OnClick();
            }
    
            public abstract class Button
            {
                public abstract void OnClick();
                public static Button CreateFromDynamic(dynamic button)
                {
                    return new Implementation(button);
                }
                private class Implementation : Button
                {
                    public Implementation(dynamic button)
                    {
                        PrivateOnClick = button.OnClick;
                    }
                    private Action PrivateOnClick { get; set; }
    
                    public override void OnClick()
                    {
                        PrivateOnClick();
                    }
                }
            }
        }
    }
