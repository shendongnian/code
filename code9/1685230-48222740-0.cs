    // Model
    public class Model{
        // ...
    }
    // View Model
    public class ViewModel {
        public ViewModel(){
            Entities = <... load entities here...>;
        }
        public IList<Model> Entities {
            get;
            private set;
        }
        public virtual Model SelectedEntity {
            get;
            set;
        }
        protected void OnSelectedEntityChanged() {
            // do something
        }
    }
    // View
    using DevExpress.XtraGrid.Views.Base;
    ...
    var fluent = mvvmContext.OfType<ViewModel>();
    // bind the datasource
    fluent.SetBinding(gridControl1, gControl => gControl.DataSource, x => x.Entities);
    // bind the FocusedRowObject
    fluent.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView1, "FocusedRowObjectChanged")
        .SetBinding(x => x.SelectedEntity,
            (args) => args.Row as Model,
            (gView, entity) => gView.FocusedRowHandle = gView.FindRow(entity));
