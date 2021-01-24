        private async void TweetButton_Click(object sender, RoutedEventArgs e)
        {
            var authorizer = new UniversalAuthorizer
            {
                CredentialStore = new InMemoryCredentialStore
                {
                    ConsumerKey = "",
                    ConsumerSecret = ""
                }
            };
            await authorizer.AuthorizeAsync();
            var ctx = new TwitterContext(authorizer);
            string userInput = tweetText.Text;
            Status tweet = await ctx.TweetAsync(userInput);
            ResponseTextBlock.Text = tweet.Text;
            await new MessageDialog("You Tweeted: " + tweet.Text, "Success!").ShowAsync();
        }
