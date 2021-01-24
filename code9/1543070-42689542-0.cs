    public class settings {
        public config conf = new config();
        public void setUserID(int listIndex, int newID) {
            conf.users[listIndex].ID = newID;
        }
        public user userPropertys(int index) { return conf.users[index]; }
    
        private class config {
            public List<user> users;
        }
    }
