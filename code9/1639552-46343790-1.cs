    private async void bt_publishPath_Click(object sender, RoutedEventArgs e)
    {
        // [...]
        HttpResponseMessage res = await ApiCall.do_POST(
            "/path",
            "admin:123456",
            "{ \"hello\" : \"world\" }"
        );
        // [...]
    }
