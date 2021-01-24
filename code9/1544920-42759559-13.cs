     private async void TestButton_Click(object sender, RoutedEventArgs e)
     {
         await dedicated();
     }
    
     private async Task dedicated()
     {
         Console.WriteLine("running on task {0}", Task.CurrentId.HasValue ? Task.CurrentId.ToString() : "null");
         await Task.Delay(TimeSpan.FromMilliseconds(100));
         Console.WriteLine("running on task {0}", Task.CurrentId.HasValue ? Task.CurrentId.ToString() : "null");
     }
