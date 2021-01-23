        protected string GetJPayWebsiteFaqTopics()
        {
            // call the FAQ manager
            var faqController = managers.GetFaqManager();
            string errors = string.Empty;
            string result = string.Empty;
            
            // All items returned from faq manager, 2d collection not grouped into topic dictionaries
            List<FaqQuestionAnswer> allFaqItemsInSelectedSystem = faqController.GetAllFaqItemsForSystem(out errors);
            // Storage for main data, prior to serialization
            List<Dictionary<string, object>> allFaqTopicsAndItems = new List<Dictionary<string, object>>();
            // Group all item Lists together in alike topic related faq items
            IEnumerable<IGrouping<string, FaqQuestionAnswer>> groupedData = from qaItem in allFaqItemsInSelectedSystem
                                                                            group qaItem by qaItem.FaqTopicName;
            // Allow the groupData to get iterated 
            IGrouping<string, FaqQuestionAnswer>[] enumerableGroups = groupedData as IGrouping<string, FaqQuestionAnswer>[] ?? groupedData.ToArray();
            JavaScriptSerializer jsonConverter = new JavaScriptSerializer();
            
            foreach (var instance in enumerableGroups)
            {
                // Each group of data should have a title for the group, a list of FAQ items
                var items = instance.ToList();
                
                // Temp storage for each topic and associated faq item data
                Dictionary<string, object> group = new Dictionary<string, object>();
                /**
                 * Temp storage for clean faq items stripped of topic level data which has now 
                 * been added to the parent node so no longer needed at this level
                 */
                List<QuestionAnswerOrderOnly> cleanedItems = new List<QuestionAnswerOrderOnly>();
                // Add the group title
                group.Add("Title", instance.Key);
                // Add the topics display order to the group data 1st item since it is on every item
                group.Add("TopicOrder", items[0].TopicOrder);
                /**
                 *  Pull the values that are important for the item only, add it to the group 
                 *  Clean up item before recording it to the group it belongs to
                 */
                cleanedItems.AddRange(items.Select(item => new QuestionAnswerOrderOnly(item.Question, item.Answer, item.ItemOrder)));
                // Add the clean faqitems collection
                group.Add("Items", cleanedItems);
                
                // Add this topic group to the result
                allFaqTopicsAndItems.Add(group);
            }
            jsonConverter.MaxJsonLength = Int32.MaxValue;
            try
            {
                result = jsonConverter.Serialize(allFaqTopicsAndItems);
            }
            catch (Exception error)
            {
                result = $"{errors} {error.Message}";
            }
            
            return result;
        }
