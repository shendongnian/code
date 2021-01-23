    public class CandidateViewModel
    {
        // add properties that the View needs from database candidates table
        string Username { get; set; } // the additional prop
        public CandidateViewModel(candidate c, string username)
        {
            // ... obvious code here
        }
    }
