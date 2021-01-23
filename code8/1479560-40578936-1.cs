    public interface IEditViewModel<TEntity>
    {
        EditResult EditEntity(TEntity entityToEdit, DialogHandler dialogHandler);
    }
    public interface IChooseViewModel<TEntity>
    {
        TEntity ChooseEntity(DialogHandler dialogHandler);
    }
    public class ChooseEntityService
    {
        private readonly Container container;
        private readonly DialogHandler dialogHandler;
        public ChooseEntityService(Container container, DialogHandler dialogHandler)
        {
            this.container = container;
            this.dialogHandler = dialogHandler;
        }
        public TEntity ChooseEntity<TEntity>()
        {
            var viewModel = this.container.GetInstance<IChooseViewModel<TEntity>>();
            return viewModel.ChooseEntity(this.dialogHandler);
        }
    }
