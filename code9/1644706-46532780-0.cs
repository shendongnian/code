    public class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
    	public QuestionConfiguration()
    	{
    		Property(p => p.Statement).HasColumnName("STATEMENT");
    		ToTable("TB_QUESTION");
    	}
    }
    
    public class DiscursiveQuestionConfiguration : EntityTypeConfiguration<DiscursiveQuestion>
    {
    	public DiscursiveQuestionConfiguration()
    	{
    		Map(p => p.Requires("TP_QUESTION").HasValue("D"));
    	}
    }
    
    public class VisualQuestionConfiguration : EntityTypeConfiguration<VisualQuestion>
    {
    	public VisualQuestionConfiguration()
    	{
    		Map(p => p.Requires("TP_QUESTION").HasValue("V"));
    	}
    }
    
    public class ObjectiveQuestionConfiguration : EntityTypeConfiguration<ObjectiveQuestion>
    {
    	public ObjectiveQuestionConfiguration()
    	{
    		Map(p => p.Requires("TP_QUESTION").HasValue("O"));
    	}
    }
