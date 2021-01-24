    Type voteRecordType = null;
    using (var scope = HttpContext.RequestServices.CreateScope())
    {
    	switch (voteRecordDto.ContentType)
    	{
    		case ContentType.Question_Asking:
    			voteRecordType = typeof(IVoteRecordRepository<QuestionVoteRecord>);
    			break;
    		case ContentType.Question_Answer:
    			voteRecordType = typeof(IVoteRecordRepository <AnswerVoteRecord>);
    			break;
    		case ContentType.Question_AnswerComment:
    			voteRecordType = typeof(IVoteRecordRepository<CommentVoteRecord>);
    			break;
    		default:
    			result = OperationResponse.Error("There is no accept Type!");
    			break;
    	}
    
    	if (voteRecordType != null)
    	{
    		using (var repository = (IDisposable)scope.ServiceProvider.GetService(voteRecordType))
    		{
    			//...
    		}
    	}
    }
