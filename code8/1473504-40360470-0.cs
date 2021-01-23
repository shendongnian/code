	using System;
	using System.ComponentModel;
	using System.Drawing;
	using System.Drawing.Drawing2D;
	using System.Windows.Forms;
	namespace Custom.Controls
	{
		public class CustomComboBox : UserControl
		{
			private const int DEFAULT_WIDTH = 121;
			private const int DEFAULT_HEIGHT = 20;
			private CustomContextMenuStrip _popupControl;
			private CustomToolStripMenuItem _selectedItem;
			private bool _bDroppedDown;
			private Color _borderColour;
			private Color _dropDownButtonColour;
			private Color _droppedDownArrowColour;
			private Color _closedArrowColour;
			private Color _dropDownBackColour;
			private Color _dropDownForeColour;
			private Color _dropDownBorderColour;
			public Color BorderColour
			{
				get
				{
					return _borderColour;
				}
				set
				{
					_borderColour = value;
					this.Invalidate();
				}
			}
			public Color ClosedArrowColour
			{
				get
				{
					return _closedArrowColour;
				}
				set
				{
					_closedArrowColour = value;
					this.Invalidate();
				}
			}
			public Color DroppedDownArrowColour
			{
				get
				{
					return _droppedDownArrowColour;
				}
				set
				{
					_droppedDownArrowColour = value;
					this.Invalidate();
				}
			}
			public Color DropDownButtonColour
			{
				get
				{
					return _dropDownButtonColour;
				}
				set
				{
					_dropDownButtonColour = value;
					this.Invalidate();
				}
			}
			public Color DropDownBorderColour
			{
				get
				{
					return _dropDownBorderColour;
				}
				set
				{
					_dropDownBorderColour = value;
					_popupControl.BorderColour = value;
					this.Invalidate();
				}
			}
			public Color DropDownBackColour
			{
				get
				{
					return _dropDownBackColour;
				}
				set
				{
					_dropDownBackColour = value;
					_popupControl.BackColor = value;
					this.Invalidate();
				}
			}
			public Color DropDownForeColour
			{
				get
				{
					return _dropDownForeColour;
				}
				set
				{
					_dropDownForeColour = value;
					_popupControl.ForeColor = value;
					this.Invalidate();
				}
			}
			public bool DropShadowEnabled
			{
				get
				{
					return _popupControl.DropShadowEnabled;
				}
				set
				{
					_popupControl.DropShadowEnabled = value;
					this.Invalidate();
				}
			}
			public bool DroppedDown
			{
				get
				{
					return _bDroppedDown;
				}
				set
				{
					_bDroppedDown = value;
					if (value)
					{
						_popupControl.Show(this, new Point(0, this.Height), ToolStripDropDownDirection.BelowRight);
					}
					else
					{
						_popupControl.Hide();
					}
					this.Invalidate();
				}
			}
			public ToolStripItemCollection Items
			{
				get
				{
					return _popupControl.Items;
				}
			}
			public CustomToolStripMenuItem SelectedItem
			{
				get
				{
					return _selectedItem;
				}
			}
			public CustomComboBox()
			{
				this.SetStyle(ControlStyles.ResizeRedraw, true);
				this.SetStyle(ControlStyles.Selectable, true);
				this.SetStyle(ControlStyles.UserMouse, true);
				this.SetStyle(ControlStyles.UserPaint, true);
				this.SuspendLayout();
				this.ResumeLayout(false);
				_popupControl = new CustomContextMenuStrip();
				_popupControl.BackColor = this.BackColor;
				_popupControl.Closed += new ToolStripDropDownClosedEventHandler(PopupControl_Closed);
				_popupControl.ItemClicked += new ToolStripItemClickedEventHandler(PopupControl_ItemClicked);
				this.Width = DEFAULT_WIDTH;
				this.Height = DEFAULT_HEIGHT;
				_selectedItem = null;
				_bDroppedDown = false;
				this.BackColor = SystemColors.Control;
				this.ForeColor = SystemColors.ControlText;
				_borderColour = SystemColors.ActiveBorder;
				_dropDownButtonColour = SystemColors.ButtonFace;
				_droppedDownArrowColour = SystemColors.ControlLight;
				_closedArrowColour = SystemColors.ControlDark;
				//Set these via the properties so they take effect on _popupControl
				this.DropDownBackColour = SystemColors.Control;
				this.DropDownForeColour = SystemColors.ControlText;
				this.DropDownBorderColour = SystemColors.ActiveBorder;
			}
			protected override void OnFontChanged(EventArgs e)
			{
				_popupControl.Font = this.Font;
				base.OnFontChanged(e);
			}
			protected override void OnMouseDown(MouseEventArgs e)
			{
				this.Invalidate();
				this.DroppedDown = !this.DroppedDown;
				base.OnMouseDown(e);
			}
			protected override void OnMouseWheel(MouseEventArgs e)
			{
				int nIndex = this.Items.IndexOf(_selectedItem);
				if (e.Delta < 0)
				{
					if (nIndex < (this.Items.Count - 1))
					{
						_selectedItem = (CustomToolStripMenuItem)this.Items[nIndex + 1];
						OnSelectedItemChanged(EventArgs.Empty);
						this.Invalidate();
					}
				}
				else if (e.Delta > 0)
				{
					if (nIndex > 0)
					{
						_selectedItem = (CustomToolStripMenuItem)this.Items[nIndex - 1];
						OnSelectedItemChanged(EventArgs.Empty);
						this.Invalidate();
					}
				}
				base.OnMouseWheel(e);
			}
			protected override void OnPaint(PaintEventArgs e)
			{
				Rectangle boundingRect = new Rectangle(0, 0, this.Width, this.Height);
				using (SolidBrush brush = new SolidBrush(this.BackColor))
				{
					e.Graphics.FillRectangle(brush, boundingRect);
				}
				ControlPaint.DrawBorder(e.Graphics, boundingRect, _borderColour, ButtonBorderStyle.Solid);
				//Draw the dropdown button background
				int nButtonWidth = SystemInformation.VerticalScrollBarWidth + SystemInformation.VerticalFocusThickness;
				Rectangle dropDownButtonRect = new Rectangle(this.Width - nButtonWidth, 0, nButtonWidth, this.Height);
				using (SolidBrush brush = new SolidBrush(_dropDownButtonColour))
				{
					e.Graphics.FillRectangle(brush, dropDownButtonRect);
				}
				//Draw the dropdown button arrow
				using (GraphicsPath path = new GraphicsPath())
				{
					Point pTopLeft = new Point()
					{
						X = (int)Math.Round((float)dropDownButtonRect.X + ((float)dropDownButtonRect.Width * 0.30f)),
						Y = (int)Math.Round((float)dropDownButtonRect.Y + ((float)dropDownButtonRect.Height * 0.35f))
					};
					Point pTopRight = new Point()
					{
						X = (int)Math.Round((float)dropDownButtonRect.X + ((float)dropDownButtonRect.Width * 0.70f)),
						Y = (int)Math.Round((float)dropDownButtonRect.Y + ((float)dropDownButtonRect.Height * 0.35f))
					};
					Point pBottom = new Point()
					{
						X = (int)Math.Round((float)dropDownButtonRect.X + ((float)dropDownButtonRect.Width * 0.5f)),
						Y = (int)Math.Round((float)dropDownButtonRect.Y + ((float)dropDownButtonRect.Height * 0.65f))
					};
					path.AddLine(pTopLeft, pTopRight);
					path.AddLine(pTopRight, pBottom);
					SmoothingMode previousSmoothingMode = e.Graphics.SmoothingMode;
					e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
					{
						using (SolidBrush brush = new SolidBrush(_bDroppedDown ? _droppedDownArrowColour : _closedArrowColour))
						{
							e.Graphics.FillPath(brush, path);
						}
					}
					e.Graphics.SmoothingMode = previousSmoothingMode;
				}
				if (_selectedItem != null)
				{
					using (SolidBrush brush = new SolidBrush(this.ForeColor))
					{
						SizeF stringSize = e.Graphics.MeasureString(_selectedItem.Text, this.Font);
						e.Graphics.DrawString(_selectedItem.Text, this.Font, brush, new Point(0, (this.Height / 2) - ((int)stringSize.Height / 2)));
					}
				}
			}
			protected override void OnSizeChanged(EventArgs e)
			{
				if (_popupControl != null)
				{
					_popupControl.MaximumItemSize = new Size(this.Width - 1, _popupControl.MaximumItemSize.Height);
					_popupControl.Width = this.Width;
				}
				base.OnSizeChanged(e);
			}
			private void OnSelectedItemChanged(EventArgs e)
			{
				if (SelectedItemChanged != null)
				{
					SelectedItemChanged(this, e);
				}
			}
			public void SelectFirstItem()
			{
				if (this.Items != null && this.Items.Count > 0)
				{
					_selectedItem = (CustomToolStripMenuItem)this.Items[0];
					OnSelectedItemChanged(EventArgs.Empty);
				}
			}
			public event EventHandler SelectedItemChanged;
			private void PopupControl_Closed(object sender, ToolStripDropDownClosedEventArgs e)
			{
				this.DroppedDown = false;
				this.Invalidate(true);
			}
			private void PopupControl_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
			{
				_selectedItem = (CustomToolStripMenuItem)e.ClickedItem;
				OnSelectedItemChanged(EventArgs.Empty);
			}
		}
	}
