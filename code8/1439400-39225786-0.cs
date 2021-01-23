    private Viewbox getHeader() {
            Grid gr = new Grid();
            var sr = Application.GetResourceStream(new Uri("Propuestas;component/img/log.xaml", UriKind.Relative));
            var img = (Canvas)XamlReader.Load(new XmlTextReader(sr.Stream));
            var logo = new Viewbox {
                Child = img,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 165
            };
            var detalles = new TextBlock {
                FontSize = 10,
                FontFamily = new FontFamily("Verdana"),
                Padding = new Thickness(logo.Width + 15, 0, 0, 0)
            };
            App.Comando.CommandText = "SELECT RazEmp, DirEmp, CpEmp, PobEmp, ProEmp, TelEmp, CifEmp FROM META4.Empresa";
            using (var reader = App.Comando.ExecuteReader())
                while (reader.Read())
                    detalles.Text = "" + reader.GetString(0).Trim() + "\n" + reader.GetString(1).Trim() + "\n" +
                                    reader.GetDecimal(2) + " - " + reader.GetString(3).Trim() + "(" +
                                    reader.GetString(4).Trim() + ")\n" + "Tlf: " + reader.GetString(5).Trim() +
                                    "\nCIF: " + reader.GetString(6).Trim();
            var pd = new TextBox {
                Text = "PEDIDO DE COMPRA " + numPCO,
                TextAlignment = TextAlignment.Left,
                FontSize = 19,
                FontFamily = new FontFamily("Verdana"),
                FontWeight = FontWeights.Bold,
                Background = new SolidColorBrush(Color.FromRgb(192, 192, 192)),
                Margin = new Thickness(logo.Width + 15, 10, 0, 20),
                BorderThickness = new Thickness(0)
            };
            gr.ColumnDefinitions.Add(new ColumnDefinition());
            gr.ColumnDefinitions.Add(new ColumnDefinition());
            gr.RowDefinitions.Add(new RowDefinition());
            gr.RowDefinitions.Add(new RowDefinition());
            Grid.SetRow(logo, 0);
            Grid.SetRow(detalles, 0);
            Grid.SetRow(pd, 1);
            Grid.SetColumn(pd, 0);
            Grid.SetColumnSpan(pd, 2);
            Grid.SetColumnSpan(detalles, 2);
            gr.Children.Add(logo);
            gr.Children.Add(detalles);
            gr.Children.Add(pd);
            Viewbox vb = new Viewbox();
            vb.Child = gr;
            vb.Measure(new System.Windows.Size(headerWidth, headerHeight));
            vb.Arrange(new Rect(15,15,headerWidth,headerHeight));
            vb.UpdateLayout();
            return vb;
        }
