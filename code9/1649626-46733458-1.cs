    class Program {
            static void Main(string[] args) {
                char ch;int len;
                Console.WriteLine("Enter the Length of the Password: ");
                len = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Character for Password:");
                ch = Convert.ToChar(Console.Read());
                printPassword(len, ch);
                Console.Read();
            }
            public static void printPassword(int len,char ch) {
                char ch1;String pass="";
                int i;
                for (i = 0; i < len; i++) {
                    pass += Console.ReadKey(true);
                    Console.Write(ch);
                }
            }
        }
