	 private CustomTooltip m_tooltip;
     private MouseHoverInputMode m_mouseHoverMode;
     private void SetupToolTips(GraphEditorInputMode mode)
		{
			m_tooltip = new CustomTooltip(m_model.TooltipImages);
			ItemHoverInputMode itemHoverMode = new ItemHoverInputMode();
			itemHoverMode.HoverItems = GraphItemTypes.Node | GraphItemTypes.Edge;
			mode.ItemHoverInputMode = itemHoverMode;
			
			m_mouseHoverMode = new MouseHoverInputMode(m_tooltip, textProvider);
			mode.MouseHoverInputMode = m_mouseHoverMode;
			mode.ItemHoverInputMode.HoveredItemChanged += new EventHandler<HoveredItemChangedEventArgs>(ToolTipEvent);
		}
		private void ToolTipEvent(object sender, HoveredItemChangedEventArgs e)
		{
			m_tooltip.Item = e.Item; 
		}
		private void textProvider(object sender, ToolTipQueryEventArgs e)
		{
			if (m_tooltip.Item is INode || m_tooltip.Item is IEdge)
			{
				e.ToolTip = " ";
			}
		}
     public class CustomTooltip : ToolTip
	  {
        private void OnPopup(object sender, PopupEventArgs e)
		 {
         }
        private void OnDraw(object sender, DrawToolTipEventArgs e)
		 {
         }
      }
