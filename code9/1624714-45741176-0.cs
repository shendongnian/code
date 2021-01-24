    class JsonParser
    {
        public int estado { set; get; }
        public string peticion { set; get; }
        public user[] usuarios { set; get; }
        public  class user
        {
            public string id_usuario { set; get; }
            public string huella_string { set; get; }
            public string nombre { set; get; }
        }
    }
