    client = new MyWebClient();
            //client.DownloadFile("http://www1.caixa.gov.br/loterias/_arquivos/loterias/D_mgsasc.zip", p1);
            client.DownloadFileCompleted += Client_DownloadFileCompleted1;    
            client.DownloadFileAsync(new Uri("http://example.com/file.zip"), path_name_to_save);
    private static void Client_DownloadFileCompleted1(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("download finished");
        }
