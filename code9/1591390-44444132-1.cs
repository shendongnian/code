    public class Composable // overhead 8 bytes
    {
        int a, b, c, d; // int 4 bytes * 4 = 16 bytes
    }
    
    public class Composite // overhead 8 bytes
    {
        Composable c = new Composable(); // 4 bytes (reference on the heap)
    }
    var composable = new Composable(); // 24 bytes
    var composite = new Composite(); // 36 bytes (24 + 12)
