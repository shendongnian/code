        /// <summary>
        ///
        /// </summary>
        /// <param name="preserveAcronyms">If true, 'PrepareXXRecord' converted to 'prepare_xx_record',
        /// otherwise to 'prepare_xxrecord'</param>
        public static void SetSimpleUnderscoreTableNameConvention(this ModelBuilder modelBuilder, bool preserveAcronyms)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                var underscored = AddUndercoresToSentence(entity.DisplayName(), preserveAcronyms);
                entity.Relational().TableName = underscored.ToLower();
            }
        }
        private static string AddUndercoresToSentence(string text, bool preserveAcronyms)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;
            var newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                    if ((text[i - 1] != '_' && !char.IsUpper(text[i - 1])) ||
                        (preserveAcronyms && char.IsUpper(text[i - 1]) &&
                         i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                        newText.Append('_');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }
