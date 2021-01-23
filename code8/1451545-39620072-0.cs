    public void metA(Parameters input)
    {
        input.a = 5;
        input.c = "hello";
        metB(input);
    }
    public void metB(Parameters input)
    {
        input.b = 10;
    }
    public class Parameters
    {
        public int a;
        public int b;
        public string c;
    }
