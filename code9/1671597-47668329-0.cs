    public class Canditate
    {
        public Canditate()
        {
            CandidateCompanyMap = new List<CandidateCompanyMap>();
            CandidateDegreeMap = new List<CandidateDegreeMap>();
            CandidateDocumentMap = new List<CandidateDocumentMap>();
            CandidateTagsMap = new List<CandidateTagsMap>();
            EducationDetails = new List<EducationDetails>();
        }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public List<CandidateCompanyMap> CandidateCompanyMap { get; set; }
        public List<CandidateDegreeMap> CandidateDegreeMap { get; set; }
        public List<CandidateDocumentMap> CandidateDocumentMap { get; set; }
        public List<CandidateTagsMap> CandidateTagsMap { get; set; }
        public List<EducationDetails> EducationDetails { get; set; }
    }
