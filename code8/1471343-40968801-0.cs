    T Find<T>(Control container) where T : Control
        {
            for (int i = 0; i < container.Controls.Count; i++)
            {
                if (container.Controls[i] is T)
                {
                    return (T)container.Controls[i];
                }
            }
            return null;
        }
    public void ChangeView<T>(Func<INavigationControl, T> createTInstance) where T : Control, new()
        {
            if (transitionManager1.IsTransition)
            {
                transitionManager1.EndTransition();
            }
            transitionManager1.StartTransition(BasePanel);
            try
            {
                T find = Find<T>(BasePanel);
                if (find != null)
                {
                    find.BringToFront();
                }
                else
                {
                    if (createTInstance == null)
                        find = new T();
                    else
                        find = createTInstance(this);
                    find.Parent = BasePanel;
                    find.Dock = DockStyle.Fill;
                    find.BringToFront();
                }
            }
            finally
            {
                transitionManager1.EndTransition();
            }
        }
    public interface INavigationControl
    {
        void ChangeView<T>(Func<INavigationControl, T> createTInstance) where T : Control, new();
    }
