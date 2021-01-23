            string[] files = { "SampleCSVFile_5300kb1.csv,SampleCSVFile_5300kb2.csv", "SampleCSVFile_5300kb3.csv" };
            int counter = 1;
            var dictionary = new Dictionary<string, string>();
            foreach (var file in files)
            {
                dictionary.Add("CSV" + counter, file);
                counter++;
            }
            counter = 1;
            foreach (var file in files)
            {
               string myValue;
             
               //You need to pass key name here  but you are passing value of it
               //Need to update here 
               string keyName = "CSV" + counter;
               if (dictionary.TryGetValue(keyName, out myValue)) ;    // getting null in out value
                counter++;
            }
