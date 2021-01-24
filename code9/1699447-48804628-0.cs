		<script>
		var KriterAlanlariHtml = new Array();
	</script>
	@{
		int sayac = 0;
		string html = "";
		foreach (var group in Model.GrupDTO)
		{
			 if (group != null && group.ListAreaDTO != null)
				{
					foreach (var area in group.ListAreaDTO)
					{
						html = BuildHtmlTag(area);
						<text>
							<script>
								KriterAlanlariHtml[@sayac] = "@MvcHtmlString.Create(html)";
							</script>
						</text>
						sayac++;
					}
				}
		}
	}
