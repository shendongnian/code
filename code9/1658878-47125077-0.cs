    public class Program
    {
        public static void Main(string[] args)
        {
            int N = 5;
            string[] items = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            var take = items.Take(N);
            string str = "";
            foreach(string s in take)
            {
                str += s;
            }
            char[] charArry = str.ToCharArray();
            permute(charArry, 0, str.Length-1);
        }
        
        static void permute(char[] arry, int i, int n)
        {
            int j;
            if (i==n)
                Console.WriteLine(arry);
            else
            {
                for(j = i; j <=n; j++)
                {
                    swap(ref arry[i],ref arry[j]);
                    permute(arry,i+1,n);
                    swap(ref arry[i], ref arry[j]);
                }
            }
        }
        static void swap(ref char a, ref char b)
        {
            char tmp;
            tmp = a;
            a=b;
            b = tmp;
        }
    }
