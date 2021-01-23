    private async void btnCourse1_Click(object sender, RoutedEventArgs e) {
        string[] names = new string[3] { "COP3488C,", "UWP1,", "This course is mobile app development." };
        await ProcessNames(names);
    }
    private async void btnCourse2_Click(object sender, RoutedEventArgs e) {
        var names = new string[3] { "DOP3488B,", "UWC1,", "This course is Cloud Computing." };
        await ProcessNames(names);
    }
    
    private async void btnCourse3_Click(object sender, RoutedEventArgs e) {
    
        var names = new string[3] { "BOP3589,", "UWP2,", "This course Computer Programming Java 1." };
        await ProcessNames(names);
    
    }
