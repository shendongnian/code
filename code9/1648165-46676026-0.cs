	public List<BracketDto> GetBrackets()
	{
		var brackets = this.Context.Brackets.Select(a => {
			return new BracketDto(){
				BracketId = a.BracketId,
				BracketName = a.BracketName,
				Teams = a.Teams.Select(b => {
					  return new TeamDto() {
						TeamId = b.TeamId,
						TeamName = b.TeamName,
						BracketId = b.BracketId
					};
				}).ToList()
			};
		}).ToList();
		return brackets;
	}
