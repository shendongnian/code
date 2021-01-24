    Dictionary<string, int> WordsWithAc = new Dictionary<string, int>();
        WordsWithAc.Add("e", 1);
        WordsWithAc.Add("t", 2);
        WordsWithAc.Add("ed", 3);
        WordsWithAc.Add("es", 4);
        WordsWithAc.Add("he", 5);
        WordsWithAc.Add("hy", 6);
        WordsWithAc.Add("id", 7);
        WordsWithAc.Add("me", 8);
        WordsWithAc.Add("ne",9);
        WordsWithAc.Add("re",10);
    private void btnEnter_Click(object sender, RoutedEventArgs e)
    {
         
        if (GlobalClassAttention.totalRecallScore >= 150)
        {
            btnLevel2.Visibility = Visibility.Visible;
        }
        if (WordsWithAc.ContainsKey(txtUserInput.Text))
        {
            GlobalClassAttention.totalRecallScore += 10;
            txtScore.Text=GlobalClassAttention.totalRecallScore.ToString();
            imgCorrectSign.Visibility = Visibility.Visible;
            imgX.Visibility = Visibility.Collapsed;
            WordsWithAc.Remove(txtUserInput.Text); //Doesn't remove it from the dictionary so the user can enter in the same word more than once
        }
        else
        {
            imgX.Visibility = Visibility.Visible;
            imgCorrectSign.Visibility = Visibility.Collapsed;
        }
    }
