    private void LoadEntryForm()
            {
                this.plhEntryForm.Controls.Clear();
                EntryForm child = this.LoadControl(this.ControlPath + "EntryForm.ascx") as EntryForm;
                if (child != null)
                {
                    child.formId = this.Id; // Pass formId from parent to child               
                    child.ID = System.IO.Path.GetFileNameWithoutExtension(this.ControlPath + "EntryForm.ascx"); // You should set EntryForm.ascx path in your project
                    this.plhEntryForm.Controls.Add(child);
                }
            }
