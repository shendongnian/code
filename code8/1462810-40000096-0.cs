	// Add this to each of your panels, the enum field can be integrated into your other behaviours as well
	public class EnumPanel : MonoBehaviour 
	{
        // configurable from the Editor, the unity way.
		public ExampleEnum Type;
	}
	// Assign all your panles in the editor (or use FindObjectsByType<EnumPanel> in Start())
	public class GUIManager : MonoBehaviour 
	{
        // configurable from the Editor, the unity way.
		public EnumPanel[] Panels;
		
		void Start()
		{
			// Optionally find it at runtime, if assigning it via the editor is too much maintenance.
			// Panels = FindObjectsByType<EnumPanel>();
			EnablePanel(ExampleEnum.AddPanel);
		}
		void EnablePanel(ExampleEnum panelType)
		{
			foreach(var panel in Panels)
			{
				if(panel.Type == panelType)
					EnablePanel(panel.gameObject);
			}
		}
		void EnablePanel(GameObject panel)
		{
			panel.setActive(true);
		}
	}
