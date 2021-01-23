            string so = System.IO.File.ReadAllText(@"C:/yourPath/yourOldCSV.CSV");
            string[] arr = so.Split('|');
            //To check if it is on 3rd column
            for (int i = 2; i < arr.Length; i = i + 3)
            {
                arr[i] = arr[i].Replace("\r\n", "");
            }
            string res = String.Join("", arr);
            System.IO.File.WriteAllText("C:/yourPath/yourNewCSV.CSV", res);
