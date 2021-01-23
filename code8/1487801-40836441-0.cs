        public class usuarioConectado
        {
            public string usuariostbl_id { get; set; } // 'hidden for'
            public string username { get; set; } // 'hidden for'
            [Display(Name = "Valoracion")]
            public ICollection<string> valoracion { get; set; }
            [Display(Name = "Usuarios Id")]
            public ICollection<string> usuariostbl_id_list { get; set; }
            [Display(Name = "Recetas Id")]
            public ICollection<string> recetastbl_id_list { get; set; }
        }
