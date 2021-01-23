            [HttpGet]
        [Route("{taskId}/list")]
        public IHttpActionResult GetTaskDocuments(string taskId)
        {
            var docs = repository.getTaskDocuments(taskId);
            if (docs != null)
            {
                return Ok(docs);
            }
            else
            {
                return Ok(new ResponseStatus() { Status = Constants.RESPONSE_FAIL, Message = repository.LastErrorMsg });
            }
        }
