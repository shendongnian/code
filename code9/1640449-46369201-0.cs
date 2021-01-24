    private void UpdateGridDataSource(){
                DataTable clone = data.Copy();
                FillData(clone, deleting);
                deleting = !deleting;
                gridControl1.BeginInvoke(new MethodInvoker(delegate { gridControl1.DataSource = clone; }));
                data = clone;
            }
