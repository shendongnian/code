            var table = XElement.Parse(@"<app>
                                            <Library Name=""Main"" Path=""C:\somefile.Xml"">
                                                <ReadingList Name=""Test1"">
                                                    <Book>Book1</Book>
                                                </ReadingList>
                                                <ReadingList Name=""Test2"">
                                                    <Book>Book2</Book>
                                                </ReadingList>
                                            </Library>
                                            <Library Name=""Backup"" Path=""C:\somefile.Xml""></Library>
                                        </app>");
            var readingList = table
                .Elements("Library")
                .FirstOrDefault(x => x.Attribute("Name")?.Value == "Main")
                ?.Elements("ReadingList")
                .FirstOrDefault(x => x.Attribute("Name")?.Value == "Test2");
