    public class Usuario
    {
        public int id { get; set; }
        public String Log { get; set; }
        public String Pwd { get; set; }
        public String User { get; set; }
        public Boolean Activo { get; set; }
        public Boolean Admin { get; set; }
        public Boolean Reportes { get; set; }
        public Usuario() { }
        public Usuario(int id,string User, bool Activo, bool Admin, bool Reportes)
        {
            this.id = id;
            this.User = User;
            this.Activo = Activo;
            this.Admin = Admin;
            this.Reportes = Reportes;
        }
        public override string ToString()
        {
            return string.Format(
                "User ID: {1}{0} at {0}Name: {2}{0}Activo: {3}",
                Environment.NewLine,
                this.id,
                this.User,
                this.Activo);
        }
    }
