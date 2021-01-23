    private static void MyAscRec(int n){
        if(n==0)
        Console.Write(n+" ");
        else{
            MyAscRec(n-1);
            Console.Write(n+" ");
        }
    }
