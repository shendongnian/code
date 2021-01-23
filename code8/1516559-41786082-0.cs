    namespace ConsoleApplication2
    {
        public static class myExtensionMethods
        {
            public static string GetSubs(this string[] input)
            {
                string value = "";
                input.Select(sub => value += $"{sub} ");
                return value;
            }
        }
        class Program
        {        
            
            async private void btnCourse1_Click(object sender, RoutedEventArgs e)
            {
                await ShowDialogAsync(new string[] { "COP3488C,", "UWP1,", "This course is mobile app development." });
            }
    
            async private void btnCourse2_Click(object sender, RoutedEventArgs e)
            {
                await ShowDialogAsync(new string[3] { "DOP3488B,", "UWC1,", "This course is Cloud Computing." });
            }
    
            async private void btnCourse3_Click(object sender, RoutedEventArgs e)
            {
                await ShowDialogAsync(new string[3] { "BOP3589,", "UWP2,", "This course Computer Programming Java 1." });
            }
    
            private async Task ShowDialogAsync(string [] myStringArray)
            {
                string VarOutput = myStringArray.GetSubs();
                txtBoxCourse.Text = VarOutput;
                var dialog = new MessageDialog(VarOutput);
                await dialog.ShowAsync();
            }
