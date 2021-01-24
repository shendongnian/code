           private async void btnCompare_Click(object sender, RoutedEventArgs e)
        {
            ProgressBarCompare.Value = 0;
            lblCompare.Content = "";
            List<string> list1= (List<string>)Application.Current.Properties["list1"];
            List<string> list2= (List<string>)Application.Current.Properties["list2"];
            List<Result> output = new List<Result>();
            List<Result> passed = new List<Result>();
            int topCount = emailList.Count;
            int currentItem = 0;
            int topBound = topCount - 1;
            while (currentItem < topCount)
            {
                var hash = await CheckOperation(list1[currentItem]); // this line perform progress bar to be filled
                var result = list2.Contains(hash);
                
                //some operations
                if (Convert.ToInt32(Math.Ceiling(100d * currentItem / topBound)) < 51)
                {
                    Style style = this.FindResource("LabelTemplateNotFilled") as Style;
                    lblCompare.Style = style;
                }
                else
                {
                    Style style = this.FindResource("LabelTemplateFilled") as Style;
                    lblCompare.Style = style;
                }
                ProgressBarCompare.Value = Convert.ToInt32(Math.Ceiling(100d * currentItem / topBound));
                lblCompare.Content = Convert.ToInt32(Math.Ceiling(100d * currentItem / topBound)) + "%";
                currentItem++;
            }
            lblCompare.Content = "COMPLETE";
        }
