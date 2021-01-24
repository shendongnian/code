    protected virtual void ObjectPropertyChanged(object sender, DataGridViewVellEventArgs e)
    {
      var selectedObject = ((DataGridView)sender).Rows[e.RowIndex].DataBoundItem;
      //Assuming you stored in a List and each Object has an ID as prop:
      var indx = _Objects.IndexOf(_Objects.Where(o => o.ID.Equals(selectedObject.ID)))
      _Objects.Remove(indx)
      _Objects.Insert(indx, selectedObject)
    }
