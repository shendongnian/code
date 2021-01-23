    private async void btnCourse1_Click(object sender, RoutedEventArgs e) {
        var names = new []{ "COP3488C,", "UWP1,", "This course is mobile app development." };
        await displayCourseInfo(names);
    }
    private async void btnCourse2_Click(object sender, RoutedEventArgs e) {
        var names = new []{ "DOP3488B,", "UWC1,", "This course is Cloud Computing." };
        await displayCourseInfo(names);
    }
    
    private async void btnCourse3_Click(object sender, RoutedEventArgs e) {    
        var names = new []{ "BOP3589,", "UWP2,", "This course Computer Programming Java 1." };
        await displayCourseInfo(names);    
    }
