        private void SoureListView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            Cars x = e.Items[0] as Cars;
            string DraggedSourceCar = x.Name;
            e.Data.Properties.Add("myArgs", DraggedSourceCar);
        }
        private void GridInsideDatatemplateOfTargetListview_Drop(object sender, DragEventArgs e)
        {
            var x = sender as Grid;
            var y = x.DataContext as Folders;
            string toMoveFolderName = y.Name;
            string DraggedSourceCar = e.DataView.Properties["myArgs"].ToString();
            Debug.WriteLine(DraggedSourceCar + Environment.NewLine + toMoveFolderName );
        }
        private void TargetListview_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
        }
