    public class PersonInfoFactory
    {
        public PersonInfo Create(Person person)
        {
            return new PersonInfo
            {
                StackOverFlowName = p.StackOverFlowName,
                Experience = p.Experience,
                GuruStatus = ExperienceBasedStatus(p.Experience)
            };
        }
        private GuruLevel ExperienceBasedStatus(int experience) => experience > 9000 ? GuruLevel.SuperSayan : GuruLevel.Goku;
    }
