    string input = "filename_20170818_010138.xml";
    var splitResult = input.Split(new string[] { "_", "." }
                            , StringSplitOptions.RemoveEmptyEntries);
    var data = DateTime.ParseExact(splitResult[1] + splitResult[2]
                                    , "yyyyMMddHHmmss"
                                    , System.Globalization.CultureInfo.InvariantCulture);
