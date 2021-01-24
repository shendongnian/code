    public static string PrepareBody(string body)
	{
		var stripHead = new Regex(@"<body.*?>|<\/body>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
		var stripScript = new Regex(@"<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
		var stripStyle = new Regex(@"<style\b[^<]*(?:(?!<\/style>)<[^<]*)*<\/style>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
		var stripFonts = new Regex(@"\sface=""(.*?)""|\ssize=""(.*?)""", RegexOptions.IgnoreCase | RegexOptions.Multiline);
		var stripInlineFontSize = new Regex(@"font-size:(.*?);", RegexOptions.IgnoreCase | RegexOptions.Multiline);
		
		var regBody = stripHead.Split(body);
		var content = "<div>" + regBody[1].Replace("\n", "\n<br />") + "</div>";
		content = stripScript.Replace(content, "");
		content = stripStyle.Replace(content, "");
		content = stripFonts.Replace(content, "");
		content = stripInlineFontSize.Replace(content, "");
		content = content.Replace("<o:p>", "")
						.Replace("</o:p>", "")
						.Replace(" class=\"WordSection1\"", "")
						.Replace(" class=\"MsoPlainText\"", "")
						.Replace(" class=\"MsoNormal\"", "")
						.Replace("mso-fareast-language:DA", "")
						.Replace("<br>", "<br />");
		return content;
	}
