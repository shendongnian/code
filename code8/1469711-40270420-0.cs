            try
            {
                var verifyResponse =
                    await
                    (from acct in twitterCtx.Account
                     where acct.Type == AccountType.VerifyCredentials &&
                           acct.IncludeEmail == true
                     select acct)
                    .SingleOrDefaultAsync();
                if (verifyResponse != null && verifyResponse.User != null)
                {
                    User user = verifyResponse.User;
                    Console.WriteLine(
                        $"Email for {user.ScreenNameResponse} is {user.Email}."); 
                }
            }
            catch (TwitterQueryException tqe)
            {
                Console.WriteLine(tqe.Message);
            }
