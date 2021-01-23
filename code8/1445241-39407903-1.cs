	public class GroupeActes
	{
		public List<Acte> Actes { get; set; }
		
		public string NomGroupe { get; set; }
		public GroupeActes(string nom, List<Acte> liste)
		{
			NomGroupe = nom;
			Actes.AddRange(acte);			
		}
	}
