    if (!string.IsNullOrEmpty(custFNameTxt.Text) && string.IsNullOrEmpty(custIdTxt.Text) ||
                !string.IsNullOrEmpty(custLNameTxt.Text) && !string.IsNullOrEmpty(custFNameTxt.Text) ||
                string.IsNullOrEmpty(custLNameTxt.Text) && !string.IsNullOrEmpty(custFNameTxt.Text)) 
            {
                searchFirstName(custFNameTxt, customers);//search first name make searched list
                custSearchList.Clear();
                foreach (Customer custs in searched)
                {
                    altRowColor(searched, custSearchList);//iterate throught list alt row color
                }
                altCust = 0;//reset altCust to avoid errors
                if (!string.IsNullOrEmpty(custFNameTxt.Text) && !string.IsNullOrEmpty(custLNameTxt.Text))//Narrow down the search
                {
                    narrowByLast();//narrow method
                    custSearchList.Clear();//clear text
                    foreach (Customer custs in searched)
                    {
                        altRowColor(searched, custSearchList);//iterate throught list alt row color
                    }
                    altCust = 0;//reset altCust to avoid errors
                }
            }
