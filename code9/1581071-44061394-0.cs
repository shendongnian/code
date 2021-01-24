    List<string> MyData = new List<string>();
                MyData.Add("4,500"); //dynamically adding. 4(april) and 6(june) are month numbers.
                MyData.Add("6,400");
                int i = 1;
                // use variable i from 1 to 12 as month indicator
                foreach (string str in MyData)
                {
                    string month = str.Substring(0, str.IndexOf(',')); 
                    // get the month from your list item here
                    int GetmonthNum = Convert.ToInt32( month==string.Empty || month==null ? i.ToString() : month  );
                   // here use conditional operator to check if month is not there in list item , if it is not present than return i as misisng month 
                    i++;
                }
