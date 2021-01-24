            InitializeComponent();
            List<string> nonReadebleFonts = new List<string>();
            nonReadebleFonts.Add("Wingdings");
            foreach (FontFamily font in Fonts.SystemFontFamilies)
            {
                ComboBoxItem boxItem = new ComboBoxItem();
                boxItem.Content = font.ToString();
                Uri s = font.BaseUri;
                if (!nonReadebleFonts.Contains(font.ToString()))
                {
                    boxItem.FontFamily = font;
                }
           
                fontsComboBox.Items.Add(boxItem);
            }
