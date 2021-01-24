    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Configurations.Add(new QuestionConfiguration());
        modelBuilder.Configurations.Add(new VisualQuestionConfiguration());
        modelBuilder.Configurations.Add(new ObjectiveQuestionConfiguration());
        modelBuilder.Configurations.Add(new DiscursiveQuestionConfiguration());
    }
