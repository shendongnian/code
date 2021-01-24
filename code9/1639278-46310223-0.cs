    public class RazorEngineRender {
        public static string RenderPartialViewToString<T>(string templatePath, string viewName, T model) {            
            string text = System.IO.File.ReadAllText(Path.Combine(templatePath, viewName));
            string renderedText = Razor.Parse(text, model);
            return renderedText;
    }
}
