     public ActionResult ScanTokensComplete(BulkTokenCreateModel bulkTokenCreateModel)
        {
            ModelState.Clear();
            var businessLayer = BusinessLayerManager.Current;
            var failedTokens = new List<Token>();
    
            foreach (var token in bulkTokenCreateModel.Tokens)
            {
                try
                {
                    token.DateAdded = DateTime.Now;
                    token.Enabled = true;
    
                    var addedToken = businessLayer.TokenAdd(token);
                }
                catch (FaultException<ArgumentNullFault> detail)
                {
                    failedTokens.Add(token);
                    ModelState.AddModelError("KeyCode", detail.Detail.Message + $" : Token : { token.KeyCode }");
                }
                catch (Exception ex)
                {
                    failedTokens.Add(token);
                    ModelState.AddModelError("KeyCode", ex.Message + $" : Token : { token.KeyCode }");
                }
            }
    
            if (failedTokens.Count == 0)
            {
                SearchCache.UpdateCache(typeof(Token), User.BrowsingClientId);
                return RedirectToAction(...);
            }
            else
            {
                ModelState.AddModelError("", "Tokens couldn't be added");
                bulkTokenCreateModel.Tokens = failedTokens;
                return View(..., bulkTokenCreateModel);
            }
        }
