        namespace Clocks
        {
            public class NormalClock
            {
      		    private Label label;
                public NormalClock(Label label)
                {
		            if(label == null)
			            throw new ArgumentNullReferenceException("label");
    
        		    this.label = label;
                    label.Text = DateTime.Now.ToLongTimeString();
                }
            }
        }
