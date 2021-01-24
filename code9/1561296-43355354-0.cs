        public static IEnumerable<Control> Flatten(this IEnumerable<Control> controls)        
        {
            var results = new List<Control>();
            foreach (var control in controls)
            {
                results.Add(control);
                control.Controls.OfType<Control>().Flatten(results);
            }
            return results;
        }
        private static void Flatten(this IEnumerable<Control> controls, List<Control> results)
        {
            foreach (var control in controls)
            {
                results.Add(control);
                control.Controls.OfType<Control>().Flatten(results);
            }
        }
        ...
        
        var textboxes = Form.Controls.Flatten()
                        .OfType<TextBox>()
                        .Where(t=>t.Name.StartsWith("textBox"))
                        .OrderBy(t=>t.Name)
                        .ToArray();
