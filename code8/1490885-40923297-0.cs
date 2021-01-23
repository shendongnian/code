    string[] timeArrivalArray = new string[10];
    public void Button1_Click(object sender, EventArgs e)
            {
                if (timeArrivalArray[2] == null)
                {
                    //keep inserting into the array since 2nd index is null
                }
                else if (timeArrivalArray[2] != null && timeArrivalArray[2] == "someInputValue")
                {
                    //2nd index is non null and some existing value found  
                    //so do something else
                }
                else
                {
                    //2nd index isn't null but input value wasn't found so keep inserting
                }
            }
