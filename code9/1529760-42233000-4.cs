    Stopwatch st = new Stopwatch();
    int[] array = new int[10000];
    int[] model = new int[10200];
    st.Start();
    var asdf = array.Concat(model.Skip(array.Length)).ToArray();
    st.Stop();
    Console.WriteLine("Concat: " + st.ElapsedMilliseconds);
    int[] arraya = new int[10000];
    int[]  modela = new int[10200];
    
    st.Restart();
    int[] result = modela;
    arraya.CopyTo(result, 0);
    st.Stop();
    Console.WriteLine("Copy: " + st.ElapsedMilliseconds);
