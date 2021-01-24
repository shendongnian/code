       ObservableCollection<Candidate> Candidates = null;
        public MainPage()
        {
            this.InitializeComponent();
            Candidates = CandidateManager.GetAllCandidates();
            Cand1.Content = CandidateManager.GetCandidateByCategoryAndSno(CandidateCategoryNo.I, CandidateSNo.I).Name;
            Cand2.Content = CandidateManager.GetCandidateByCategoryAndSno(CandidateCategoryNo.I, CandidateSNo.II).Name;
            Cand3.Content = CandidateManager.GetCandidateByCategoryAndSno(CandidateCategoryNo.I, CandidateSNo.III).Name;
        }
        private void Cand1_Click(object sender, RoutedEventArgs e)
        {
            Candidate chosenOne = Candidates.Where(c => c.Name == Cand1.Content).FirstOrDefault();
            chosenOne.VoteCount += 1;
            Candidates.Where(c => c.Name == Cand1.Content).FirstOrDefault().VoteCount = chosenOne.VoteCount;
        }
        private void Cand2_Click(object sender, RoutedEventArgs e)
        {
            Candidate chosenOne = Candidates.Where(c => c.Name == Cand2.Content).FirstOrDefault();
            chosenOne.VoteCount += 1;
            Candidates.Where(c => c.Name == Cand2.Content).FirstOrDefault().VoteCount = chosenOne.VoteCount;
        }
        private void Cand3_Click(object sender, RoutedEventArgs e)
        {
            Candidate chosenOne = Candidates.Where(c => c.Name == Cand3.Content).FirstOrDefault();
            chosenOne.VoteCount += 1;
            Candidates.Where(c => c.Name == Cand3.Content).FirstOrDefault().VoteCount = chosenOne.VoteCount;
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Candidate chosenOne = Candidates.Where(c => c.VoteCount == 1).FirstOrDefault();
            if (chosenOne != null)
                Res.Text = chosenOne.Name + " -- " + chosenOne.VoteCount.ToString();
            else
                Res.Text = "null";
        }
