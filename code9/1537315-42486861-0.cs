    var deleteListener = new DeleteListener();
    _configuration.SetListener(ListenerType.Delete, deleteListener);
    class DeleteListener : DefaultDeleteEventListener {
        public override void OnDelete(DeleteEvent e, ISet<object> transientEntities) {
            MyEntity entity = e.Entity as MyEntity;
            if (entity != null) {
                // code for file deletion
            }
            base.OnDelete(e, transientEntities);
        }
    }
