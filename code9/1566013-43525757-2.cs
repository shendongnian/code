    // top of code file
    using System.Linq;
    using System.IO;
    // top of code file
	public Config config { get; set; }
	public void ParseMethod() {
		var text = System.IO.File.ReadAllLines("config.txt")
			.Select(x => x.Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries))
			.Where(x => x.Length > 1)
			.Select(x => new {Name = x[0].Trim(), Value = x[1].Trim()})
			.ToList();
		config = new Config(){
			DatabaseHost = text.FirstOrDefault(x => x.Name == "DatabaseHost")?.Value,
			DatabaseUsername = text.FirstOrDefault(x => x.Name == "DatabaseUsername")?.Value,
			DatabasePassword = text.FirstOrDefault(x => x.Name == "DatabasePassword")?.Value,
			DatabaseName = text.FirstOrDefault(x => x.Name == "DatabaseName")?.Value,
		};
	}
