    /// <summary>
	/// Reset input fields within a collection of Controls back to their empty/cleared states
	/// </summary>
	/// <param name="ctrls"></param>
	/// <remarks>Will clear textboxes, dropdownlists and checkboxes. Checkboxes will be reset to un-checked.</remarks>
    private void ClearInputs(ControlCollection ctrls)
    {
	  foreach (Control ctrl in ctrls) {
		if (ctrl is TextBox) {
			((TextBox)ctrl).Text = string.Empty;
		} else if (ctrl is DropDownList) {
			((DropDownList)ctrl).ClearSelection();
		} else if (ctrl is CheckBox) {
			((CheckBox)ctrl).Checked = false;
		} else if (ctrl is HiddenField) {
			((HiddenField)ctrl).Value = string.Empty;
		}
		ClearInputs(ctrl.Controls);
	  }
    }
