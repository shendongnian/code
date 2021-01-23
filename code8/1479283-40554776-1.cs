    for (var i = 0; i < 10; i++)
    {
        var temp = i;
        //Console.WriteLine("Start "+i); 
        System.Threading.Thread thread = new System.Threading.Thread(() => ExecuteInBackground(temp));
