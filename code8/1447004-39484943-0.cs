    public SubQuestionBox()
    {
        InitializeComponent();
        Children = SubQuestionsContainer.Children;
    
        // add listener for Loaded event and call OnLoaded()     
        Loaded += OnLoaded; 
        if (ParentQuestion != null)
            // The BinaryQuestion has a AnswerChanged event
            ParentQuestion.AnswerChanged += ToggleCollapse;
    }
    
    public void DistributeQuestions()
    {
        // This method seems super hacky to me. 
        // I would have thought there is a more elegant way
    
        UIElement parent = null;
        if (Children != null)
        {
            parent = Children[0];
            Children.RemoveAt(0);
        }
        if (ParentContainer != null && parent != null)
        {
            ParentContainer.Children.Add(parent);
        }
            
    }
    
    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        DistributeQuestions();
    }
