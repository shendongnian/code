    public class ItemGenerator
    {
        public List<int> List { get; } = new List<int>();
        public async Task GetItems(CancellationToken token)
        {
            int i = 0;
            while(!token.IsCancellationRequested)
            {
                List.Add(i);
                await Task.Delay(1000);
                i++;
            }
        }
    }
