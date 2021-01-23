    public class ExtractCookieField : WebTestRequestPlugin
    {
        public string AllCookiesCP { get; set; }
        public string FieldWantedCP { get; set; }
        public string SavedFieldCP { get; set; }
        // Expected to be called with AllCookiesCP containing text similar to:
        //     SomeHeader=639025785406236250; path=/; XSRF-TOKEN=somestring; secure; HttpOnly
        public override void PreRequestDataBinding(object sender, PreRequestDataBindingEventArgs e)
        {
            string AllCookiesText = e.WebTest.Context[AllCookiesCP].ToString();
            foreach (string nameValuePair in AllCookiesText.Split(';'))
            {
                string[] nameAndValue = nameValuePair.Split(new char[] { '=' }, 2);
                if (nameAndValue[0].Trim() == FieldWantedCP)
                {
                    string sessionTokenId = nameAndValue[1].Trim();
                    e.WebTest.Context[SavedFieldCP] = sessionTokenId;
                    e.WebTest.AddCommentToResult(string.Format("Setting {{{0}}} to '{1}'", SavedFieldCP, sessionTokenId));
                    return;
                }
            }
            // Dropping out of the loop means that the field was not found.
            throw new WebTestException(string.Format("Cannot extract cookie field '{0}' from '{1}'", FieldWantedCP, AllCookiesText));
        }
    }
