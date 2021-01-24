        private void handleLinks(List<EmailProperties> properties)
        {
            using (WebClient client = new WebClient())
            {
                foreach (var prop in properties)
                {
                    string link = searchForLink(prop.Body);
                    string fileName = MyExtensions.Between(link, "https://www.nfirs.fema.gov/biarchive/", ".zip");
                    string saveTo = string.Format((@"C:\Users\Foo\Downloads\{0}.zip"), fileName);
                    prop.Name = fileName;
                    client.DownloadFile(link, saveTo);
                }
            }
        }
