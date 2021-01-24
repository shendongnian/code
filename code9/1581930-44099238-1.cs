    using( var scope = new TransactionScope() ){    
        if( !HasVoted( userId, postId ) ){
            SaveVote( userId, postId, voteTypeId );
            UpdateVoteCount( postId, voteTypeId );
        }
    
        scope.Complete();
    }
