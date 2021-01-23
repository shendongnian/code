    public interface IProfession
    {
        List<string> JobSkills { get; set; }
        void SetSkills();
    }    
    
    public class Artisan : IProfession
    {
        public List<string> JobSkills { get; set; };
    
        public void SetSkills()
        {
        }
    }
