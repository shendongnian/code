	internal class CheckBoxItem : ITemplate
	{
		/// <summary>
		/// The CheckBoxItem constructor
		/// </summary>
		/// <param name="editable">true if the item is to be in its editable state, false for the item to be disabled.</param>
		public CheckBoxItem(bool editable)
		{
			readOnly = (editable==true)?false:true;
		}
		/// <summary>
		/// Instantiates the CheckBox that we wish to represent in this column. 
		/// </summary>
		/// <param name="container">The container into which the control or controls are added.</param>
		void ITemplate.InstantiateIn(Control container)
		{
			CheckBox box = new CheckBox();
			box.DataBinding += new EventHandler(this.BindData);
			box.AutoPostBack = autoPostBack;
			box.CheckedChanged += new EventHandler(this.OnCheckChanged);
			container.Controls.Add(box);
		}
		/// <summary>
		/// Our CheckChanged event
		/// </summary>
		public event EventHandler CheckedChanged;
		/// <summary>
		/// This is a common handler for all the Checkboxes.
		/// </summary>
		/// <param name="sender">The raiser of this event a CheckBox.</param>
		/// <param name="e">A System.EventArgs that contains the event data.</param>
		private void OnCheckChanged(object sender, EventArgs e)
		{
			if (CheckedChanged != null)
			{
				CheckedChanged(sender, e);
			}
		}
		/// <summary>
		/// The internal storage for which DataField we are going to represent.
		/// </summary>
		private string dataField;
		/// <summary>
		/// Used to set the DataField that we wish to represent with this CheckBox.
		/// </summary>
		public string DataField
		{
			get
			{
				return dataField;
			}
			set
			{
				dataField=value;
			}
		}
		/// <summary>
		/// The internal storage for the AutoPostback flag.
		/// </summary>
		private bool autoPostBack=false;
		/// <summary>
		/// Set the AutoPostBack flag. If this is true then each time a CheckBox is clicked 
		/// in the Column that contains this item then an event is raised on the server.
		/// </summary>
		public bool AutoPostBack
		{
			set
			{
				autoPostBack = value;
			}
			get
			{
				return autoPostBack;
			}
		}
		/// <summary>
		/// Handler for the DataBinding event where we bind the data for a specific row 
		/// to the CheckBox.
		/// </summary>
		/// <param name="sender">The raiser of the event.</param>
		/// <param name="e">A System.EventArgs that contains the event data.</param>
		private void BindData(object sender, EventArgs e)
		{
			CheckBox box = (CheckBox) sender;
			DataGridItem container = (DataGridItem) box.NamingContainer;
			box.Checked = false;
			box.Enabled = (readOnly == true) ? false:true;
			string data = ((DataRowView) container.DataItem)[dataField].ToString();
			Type t = ((DataRowView)container.DataItem).DataView.Table.Columns[dataField].DataType;
			if (data.Length>0)
			{
				switch (t.ToString())
				{
					case "System.Boolean":
						if (( data == "True") || (data == "true"))
						{
							box.Checked = true;
						}
						break;
					default:
						break;
				}
			}
		}
		/// <summary>
		/// Internal storage for the readOnly flag.
		/// </summary>
		private bool readOnly = true;
	}
