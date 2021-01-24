        private async Task DoItAsync(string s, int d)
        {
            Console.WriteLine($"starting {s}");
            await Task.Delay(d * 1000);
            Console.WriteLine($"ending {s}");
        }
        private async Task DoItAsync(Task pre1, Task pre2, string s, int d)
        {
            await pre1;
            await pre2;
            await DoItAsync(s, d);
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            Task atask = DoItAsync("A", 2);
            Task btask = DoItAsync("B", 10);
            Task ctask = DoItAsync("C", 2);
            Task bcdtask = DoItAsync(btask, ctask, "D", 2);
            Task abetask = DoItAsync(btask, atask, "E", 2);
            await bcdtask;
            await abetask;
        }
