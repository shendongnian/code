    int size = 10000000;
    int[] arr = new int[size];
    Random rnd = new Random(1);
    arr[0] = 0;
    for(int i = 1; i < size; ++i)
    {
        if (rnd.Next(100) < 25)
        {
            arr[i] = arr[i - 1] + 2;
        }
        else
        {
            arr[i] = arr[i - 1] + 1;
        }
    }         
    System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
    st.Start();
    var res = Group(arr).ToList();
    st.Stop();
    MessageBox.Show(st.ElapsedMilliseconds.ToString());
    MessageBox.Show(res.Sum(s => s.Length).ToString());// to be sure the work is done
