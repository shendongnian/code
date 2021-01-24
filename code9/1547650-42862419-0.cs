        [HttpPost]
        [Route("GenericEvent")]
        public void GenericEvent([FromBody] string text)
        {
            eventAggregator.Publish(new GenericEvent<string>(text));
        }
