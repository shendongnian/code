    Queue<int> queue =
       new Queue<int>(Enumerable.Range(1, 10).Concat(Enumerable.Range(2, 8).Reverse()));
    
    private void dt_Tick(object sender, EventArgs e)   
    {
        var a = queue.Dequeue();
        Label1.Content = a.ToString();
        queue.Enqueue(a);
    }
