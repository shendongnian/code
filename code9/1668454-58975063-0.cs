        protected string GetCanonicalValue(string entityName, LuisResult intentContext)
        {
            List<EntityRecommendation> intentList = intentContext.Entities.Where(x => x.Type.Equals(entityName)).ToList();
            string canonicalForm = string.Empty;
            foreach (EntityRecommendation entity in intentList)
            {
                IEnumerator<object> dict = entity.Resolution.Values.GetEnumerator();
                dict.MoveNext();
                List<object> valuesList = (List<object>)dict.Current;
                canonicalForm = (string)valuesList[0];
            }
            return canonicalForm;
        }
