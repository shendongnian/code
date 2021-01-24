        public override string ToString(List<List<Event>> listOflistOfEvents)
        {
            StringBuilder result = new StringBuilder();
            listOflistOfEvents.ForEach(delegate(List<Event> listOfEvents)
            {
                result.AppendLine();
                listOfEvents.ForEach(events => result.Append(events + ","));
            });
            return result.ToString();
        }
