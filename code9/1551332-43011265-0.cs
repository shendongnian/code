	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	internal sealed class MinifyHtmlAttribute :
		ActionFilterAttribute {
		public override void OnActionExecuted(
			ActionExecutedContext filterContext) {
			if (filterContext == null
				|| filterContext.IsChildAction) {
				return;
			}
			filterContext.HttpContext.Response.Filter = new MinifyHtmlStream(filterContext.HttpContext);
		}
	}
	internal sealed class MinifyHtmlStream :
		MemoryStream {
		private readonly MemoryStream BufferStream;
		private readonly HttpContextBase Context;
		private readonly Stream FilterStream;
		public MinifyHtmlStream(
			HttpContextBase httpContextBase) {
			BufferStream = new MemoryStream();
			Context = httpContextBase;
			FilterStream = httpContextBase.Response.Filter;
		}
		public override void Flush() {
			BufferStream.Seek(0, SeekOrigin.Begin);
			if (Context.Response.ContentType != "text/html") {
				BufferStream.CopyTo(FilterStream);
				return;
			}
			var document = new HtmlDocument();
			document.Load(BufferStream);
			var spans = document.DocumentNode.Descendants().Where(
				d =>
					d.NodeType == HtmlNodeType.Element
					&& d.Name == "span").SelectMany(
				d => d.ChildNodes.Where(
					cn => cn.NodeType == HtmlNodeType.Text)).ToList();
			//	Some spans have content that needs to be trimmed.
			foreach (var span in spans) {
				span.InnerHtml = span.InnerHtml.Trim();
			}
			var nodes = document.DocumentNode.Descendants().Where(
				d =>
					(d.NodeType == HtmlNodeType.Text
					&& d.InnerText.Trim().Length == 0)
					|| (d.NodeType == HtmlNodeType.Comment
					&& d.InnerText.Trim() != "<!DOCTYPE html>")).Select(
				d => d).ToList();
			foreach (var node in nodes) {
				node.Remove();
			}
			document.Save(FilterStream);
		}
		public override void Write(
			byte[] buffer,
			int offset,
			int count) {
			BufferStream.Write(buffer, offset, count);
		}
	}
