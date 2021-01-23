    private void Button_Click(object sender, RoutedEventArgs e)
    {   
        Task.Run(() => OnlineModeSendData(data1));
        Task.Run(() => OnlineModeSendData(data2));
    }
    private void OnlineModeSendData(List<string> data)
    {
        Port.WriteLine(STARTCHARACTER + XMLSET + XML_TAG_START + data[0]+ XML_TAG_STOP + data[1] + ENDCHARACTER);
        string received = Port.ReadLine();
    }
