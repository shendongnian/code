    public void solve(int a,int b,int c,int n,PictureBox[] arr)
    {
        if (n == 1)
        {
            h[c].Push(h[a].Pop());
            print(arr);
            return;
        }
        //like here 
        System.Threading.Thread.Sleep();
        solve(a, c, b, n - 1,arr);
        h[c].Push(h[a].Pop());
        solve(b, a, c, n - 1, arr);
        print(arr);        
    }
