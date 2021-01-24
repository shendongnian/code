    int mainCounter = 0;
    int totalItems = 0;
    List<string> LstItems = new List<string>();
    private void Form1_Load(object sender, EventArgs e)
    {
       LstItems.Add("Test Item 1");
       LstItems.Add("Test Item 2");
       LstItems.Add("Test Item 3");
       LstItems.Add("Test Item 4");
       LstItems.Add("Test Item 5");
       totalItems = LstItems.Count();
    }
    private void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
           if (mainCounter > totalItems)
           {
              //your implementation
              return;
           }
           txtNext.Text = LstItems[mainCounter].ToString();
           mainCounter++;
        }
        catch (Exception)
        {
        }
    }
