		protected EntityValueGroupViz(SerializationInfo info, StreamingContext context)
        {
            foreach (SerializationEntry entry in info)
            {
            	switch (entry.Name)
                {
					case "SelectedValues":
						foreach (SelectedValue sv in (IEnumerable<SelectedValue>)entry.Value)
							this.Value(sv);
						break;
                }
            }
        }
