    public async Task GetResults(int[] productIDsToGet) {
        var tasks = new List<Task>();
        foreach (int productID in productIDsToGet) {
           Task task = GetResultFromEbay(productID);
           tasks.Add(task);
        }
        // Wait for all of the tasks to complete
        await Task.WhenAll(tasks);
    }
    private async Task GetResultFromEbay(int productIdToGet) {
        // Get result asynchronously from eBay
    }
