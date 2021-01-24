          private string SearchbyPayRate(string term, List<string> PeopleList)
   
         {try
             {
              string result = "not found"; //initial value of search result
   
   
            //prepare for the search item from parameter
            int employeeid = int.Parse(term);
            for (int i = 0; i < PeopleList.Count; i++) //The list is search through one by one
            {   //In order to separate employee id from other items in a line, each line is split into 3 items (fields) by ","
                string[]vals = PeopleList[i].Split(',');
                int id = int.Parse(vals[0]); //Employment id is at the first item
                if (id == employeeid) //Found
                {
                    decimal hours = decimal.Parse(tbxwageworkinghrs.Text);
                    decimal payrate = decimal.Parse(vals[2]);
                    decimal wage = hours * payrate;
                    result = "Employee " + vals[0] + " Wage Details:" + ",Pay rate is $" + vals[2] + ",Working hours is " + hours + ",Wage is $" + wage;
                }
            }
            return result; //Send a single result string back to the main program which calls this method
        }  
    catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return null;
        }
        }
    private void btngrosspay_Click(object sender, EventArgs e)
    {try
        {//Saved data file needs to be loaded before the search
            if (People == null)
            {
                MessageBox.Show("No data is loaded from saved file!", "Click button \"Load File\""); }
                //Display special symbol, \ is used
                else
            {   //A single variable is used to receive only one search result by calling a SearchbyPayRate method
                //This method has two parameters, employee id from textbox and a list of loaded people data from the daved file
                string eidResult = SearchbyPayRate(tbxwageempid.Text, People);
                //Output the single result
                lbxwagedetails.Items.Clear();
                lbxwagedetails.Items.AddRange(eidResult.Split(',').ToArray());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
