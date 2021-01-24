    public class BindableMenuItem
    {
    	public BindableMenuItem(string name, ICommand command)
    	{
    		this.Name = name;
    		this.Command = command;
    	}
    	public string Name { get; set; }
    	public ICommand Command { get; set; }
    	public string IconName { get; set; }
    	public ObservableCollection<BindableMenuItem> Children { get; set; }
    }
