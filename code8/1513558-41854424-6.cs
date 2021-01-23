    public static class BusinessToHtmlHelper {
        public static MvcHtmlString FromBusinessObject( this HtmlHelper html, Person person) {
            string personLink = html.ActionLink(person.Name, "Detail", "People",
                new { id = person.Id }, null).ToHtmlString();
            return new MvcHtmlString(personLink + " (" + person.Id + ")");
        }
        public static MvcHtmlString FromBusinessObject( this HtmlHelper html,
            Department department) {
            string departmentLink = html.ActionLink(department.Name, "Detail", "Departments",
                new { id = department.Id }, null).ToHtmlString();
            return new MvcHtmlString(departmentLink + " (" + department.Id + ")");
        }
    }
