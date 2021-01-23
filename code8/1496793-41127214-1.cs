            private async void btnProcess_Click(object sender, EventArgs e)
            {
                await processFiles();
            }
            async Task<int> processFiles()
            {
                var processingTasks = new List<Task>();
                foreach (string fileName in listBox1.Items)
                {
                    processingTasks.Add(process012(fileName));
                    processingTasks.Add(process123(fileName));
                    processingTasks.Add(process234(fileName));
                }
                await Task.WhenAll(processingTasks);
                return (1);
            }
            Task<int> process173(string fileName)
            {
                return Task.FromResult(retVal)
            }
            Task<int> process032(string fileName)
            {
                return Task.FromResult(retVal)
            }
            Task<int> process018(string fileName)
            {
               return Task.FromResult(retVal)
            }
