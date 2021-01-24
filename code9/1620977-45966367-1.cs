    public void Post([FromBody] JsonData data)
        {
            try
            {
                var entry = data.Entry.FirstOrDefault();
                //Get change
                var change = entry?.Changes.FirstOrDefault();
                if (change == null) return;
                //Get lead Id
                var leadId = change.Value.LeadGenId;
                //Lead Id is used for further processing
            }
            catch (Exception ex)
            {
                Trace.TraceError($"Error >> {ex.Message} >> StackTrace {ex.StackTrace}");
            }
        }
