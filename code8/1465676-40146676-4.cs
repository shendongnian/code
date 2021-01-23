    public class Hello1
    {
       public static void Main()
       {
            string[] inputs = {"abc","abb","aba"};
            Swap(inputs,1,3);
            Copy_Alloc(inputs[2]);
       }
       private static void Swap(const string[] inputs,int i,int j)
       {
            string tmp = inputs[i];
            inputs[i] = inputs[j];
            inputs[j] = tmp;
       }
       private static void Copy_Alloc(string inputs)
       {
            string copy = string.Copy(inputs);
            string another = "abc";
            string combined = copy + "cba";
       }
    }
