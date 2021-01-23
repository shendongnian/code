        /// <summary>
        /// First organizes all FAQ items by topic property, removes topic data by from item level and groups results by topic desc
        /// </summary>
        /// <param name="allFaqItemsInSelectedSystem">2d collection of all faq items to be restructured.</param>
        /// <param name="outErrors">Errors out.</param>
        /// <returns>JSON string containing questionAnswer data inside of related topic objects</returns>
        public string SortAndRestructureFaqItemsData(List<FAQQuestionAnswer> allFaqItemsInSelectedSystem, out string outErrors)
        {
            string jsonResult = string.Empty;
            string errors = string.Empty;
            // Final result, collection of unique groups
            List<FAQGroupedTopicsItemsQuestionsAnswers> groupsCollection = new List<FAQGroupedTopicsItemsQuestionsAnswers>();
            
            foreach (var faq in allFaqItemsInSelectedSystem)
            {   
                // Get topic name from faq data.
                string topicName = faq.TopicName;
                // Get group name from faq data.
                string groupName = faq.GroupName;
                // Is this a new group or existing?
                bool groupExists = groupsCollection.Any(faqGroup => faqGroup.GroupName == faq.GroupName);
                
                // Is this topic new or existing?
                bool topicExists = groupsCollection.Any(faqGroup => faqGroup.GroupTopics.Any(faqTopic => faqTopic.Title == topicName));
                
                // New temp topic.
                FAQTopicsWithItemsResult newTopic = new FAQTopicsWithItemsResult(topicName, faq.TopicOrder, new List<FAQQuestionAnswerOnly>());
                // Check if this group exists.
                if (groupExists)
                {
                    // Check if the topic exists inside of this group
                    if (topicExists)
                    {
                        // Since the and group exists, add the newTopic to it which also contains the first item.
                        groupsCollection.Find(faqGroup => faqGroup.GroupName == groupName).GroupTopics.Find(faqTopic => faqTopic.Title == topicName).Items.Add(new FAQQuestionAnswerOnly(faq.Question, faq.Answer, faq.ItemOrder));
                    }
                    else
                    {
                        // Since the group exists but not the topic, add the new topic containing the new item to the matching group.
                        groupsCollection.Find(faqGroup => faqGroup.GroupName == groupName).GroupTopics.Add(newTopic);
                    }
                }
                else
                {
                    // Since this is a new group, add it along with the new topic, and new faqItem
                    groupsCollection.Add(new FAQGroupedTopicsItemsQuestionsAnswers(groupName, faq.GroupSortOrder, new List<FAQTopicsWithItemsResult> { newTopic }));
                }
            }   
            try
            {
                jsonResult = JsonConvert.SerializeObject(groupsCollection);
            }
            catch (Exception error)
            {
                errors = error.Message;
            }
            outErrors = errors;
            return jsonResult;
        }
