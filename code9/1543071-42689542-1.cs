    public class settings {
        public config conf = new config();
        public void setUserID(int listIndex, int newID) {
            conf.users[listIndex].ID = newID;
        }
        public List<user> userPropertys { return conf.users; }
    
        private class config {
            public List<user> users;
        }
    }
