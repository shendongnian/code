    public class Repository {
        private readonly ISession session;
        
        public Repository(NHibernate.ISession session) {
            this.session = session;
        }
        
        public void DoSomething() {
            this.session.SaveOrUpdate(...);
        }
    }
