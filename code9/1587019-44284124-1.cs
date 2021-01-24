    public class Fruit
    {
        public static Fruit CreateFruit(string v1, string v2)
        {
            return new Apple(v1, v2);
        }
        public static Fruit CreateFruit(string v1, int v2, int v3)
        {
            return new Orange(v1, v2, v3);
        }
    }
    public class Apple : Fruit
    {
        string var1 { get; set; }
        string var2 { get; set; }
        public Apple(string v1, string v2)
        {
            this.var1 = v1;
            this.var2 = v2;
        }
    }
    public class Orange : Fruit
    {
        string var1 { get; set; }
        int var2 { get; set; }
        int var3 { get; set; }
        public Orange(string v1, int v2, int v3)
        {
            this.var1 = v1;
            this.var2 = v2;
            this.var3 = v3;
        }
    }
