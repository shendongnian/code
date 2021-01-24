    public static void Main(string[] args)
    {
        string s = "C:\\Users\\me\\Desktop\\filename.This.Is.An.Extension";
        string newString="";
        for(int i=0;i<s.Length;i++)
        {
            if(s[i]=='.'){
                break;
            }else{
               newString += s[i].ToString();
            }
        }
        Console.WriteLine(newString); //writes "C:\Users\me\Desktop\filename"
    }
