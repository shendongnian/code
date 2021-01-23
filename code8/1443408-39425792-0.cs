    private static async Task getAllLiveTips()
        {
            var query = new ParseQuery<ParseTip>().OrderByDescending("updatedAt").Limit(5);
            IEnumerable<ParseTip> parseTips = await query.FindAsync();
            if (parseTips != null)
            {
                foreach (var liveTip in parseTips)
                {
                    Log.Debug(TAG, "Adding live tip item");
                    App.Current.modelManager.SaveLocalTip(ModelUtils.parseToLocalTip(liveTip));
                }
            }
        } 
