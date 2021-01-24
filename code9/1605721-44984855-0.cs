           private static void Main(string[] args) {
                try {
                    Console.WriteLine(MyClass.randomkey.Next());
                    System.Threading.Thread.Sleep(5);
                    var x = new MyClass();
                    Console.WriteLine(x.returnkey());
                    System.Threading.Thread.Sleep(5);
                    var y = new MyClass();
                    Console.WriteLine(y.returnkey());
                    Console.ReadLine();
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }
