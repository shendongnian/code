    private Queue<Ray>queue = new Queue<Ray>();
    public void AddToQueue(Ray ray)
    {
       if(this.queue.Count > 12){ this.queue.Dequeue(); }
       this.queue.Enqueue(ray);
    }
    public Ray[] GetRays()
    { 
        return this.queue.ToArray();
    } 
