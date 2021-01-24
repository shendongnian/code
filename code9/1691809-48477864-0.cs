     [ContentProperty("AddContent")]
     public class YourView: ContentView
     {
        protected ContentView ContentContainer;
        public View AddContent
		{
			get => ContentContainer.Content;
			set => ContentContainer.Content = value;
		} 
        ......
     }
     //in xaml
     <YourView>
       <Label Text="Hello world"/>
     </YourView>
