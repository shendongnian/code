       modelBuilder.Entity<SessionFeedbackModel>(entity =>
            {
                entity.HasOne(s => s.Session).WithOne(p => p.Feedback)
                    .HasForeignKey<SessionFeedbackModel>(s => s.SessionId).OnDelete(DeleteBehavior.Restrict);
            });
    
            modelBuilder.Entity<SessionQuestionModel>(entity =>
            {
                entity.HasOne(e => e.SessionResult).WithOne(e => e.SessionQuestion)
                    .HasForeignKey<SessionQuestionResultModel>(e => e.SessionQuestionId)
                    .OnDelete(DeleteBehavior.Restrict);
                
            });
