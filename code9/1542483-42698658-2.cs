        private void UpdateForeignKeys(string foreignKeyName, int idValue, IEnumerable<KeyValuePair<string, object>> commands)
        {
            foreach(var command in commands)
            {
                Type itemType = command.Value.GetType();
                var keyProp = itemType.GetProperty(foreignKeyName);
                if(keyProp != null)
                {
                    keyProp.SetValue(command.Value, idValue);
                }
            }
        }
