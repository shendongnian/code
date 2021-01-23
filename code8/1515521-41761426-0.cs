    using System;
    using UIKit;
    using System.ComponentModel;
    using Foundation;
    using CoreGraphics;
    
    namespace RidderCRM.iOS.CustomControls
    {
        [Register("RidderDetailLabel")]
        public class RidderDetailLabel
            : UIView, IComponent
        {
            private UIImageView _iconImageView;
            private UILabel _titleLabel;
            private UILabel _subtitleLabel;
    
            private bool _didSetupConstraints = false;
    
            public RidderDetailLabel() { }
    
            public RidderDetailLabel(IntPtr handle) : base(handle) { }
    
            #region IComponent implementation
            public ISite Site { get; set; }
            public event EventHandler Disposed;
            #endregion
    
            [Export("TitlePosition"), Browsable(true)]
            public TitlePosition TitlePosition { get; set; }
    
            [Export("Icon"), Browsable(true)]
            public UIImage Icon { get; set; }
    
            [Export("Title"), Browsable(true)]
            public string Title { get; set; }
    
            [Export("TitleTextColor"), Browsable(true)]
            public UIColor TitleTextColor { get; set; }
    
            [Export("Subtitle"), Browsable(true)]
            public string Subtitle { get; set; }
    
            [Export("SubtitleTextColor"), Browsable(true)]
            public UIColor SubtitleTextColor { get; set; }
    
            public override void AwakeFromNib()
            {
                base.AwakeFromNib();
    
                Initialize();
            }
    
            private void Initialize()
            {
                _iconImageView = new UIImageView
                {
                    Image = Icon,
                    ContentMode = UIViewContentMode.ScaleToFill,
                    TranslatesAutoresizingMaskIntoConstraints = false
                };
    
                _titleLabel = new UILabel
                {
                    Text = Title,
                    TextColor = TitleTextColor,
                    Font = UIFont.SystemFontOfSize(17),
                    TranslatesAutoresizingMaskIntoConstraints = false
                };
    
                _subtitleLabel = new UILabel
                {
                    Text = Subtitle,
                    TextColor = SubtitleTextColor,
                    Font = UIFont.SystemFontOfSize(12),
                    TranslatesAutoresizingMaskIntoConstraints = false
                };
    
                AddSubview(_iconImageView);
                AddSubview(_titleLabel);
                AddSubview(_subtitleLabel);
            }
    
            public override void UpdateConstraints()
            {
                if (!_didSetupConstraints)
                {
                    SetupConstraints();
    
                    _didSetupConstraints = true;
                }
    
                base.UpdateConstraints();
            }
    
            private void SetupConstraints()
            {
                // Add Icon constraints
                AddConstraint(_iconImageView.RightAnchor.ConstraintEqualTo(RightAnchor, -16));
                AddConstraint(_iconImageView.CenterYAnchor.ConstraintEqualTo(CenterYAnchor));
                AddConstraint(_iconImageView.WidthAnchor.ConstraintEqualTo(25));
                AddConstraint(_iconImageView.HeightAnchor.ConstraintEqualTo(25));
    
                // Add Title constraints
                AddConstraint(_titleLabel.TopAnchor.ConstraintEqualTo(TopAnchor, 12));
                AddConstraint(_titleLabel.LeftAnchor.ConstraintEqualTo(LeftAnchor, 16));
                AddConstraint(_titleLabel.RightAnchor.ConstraintEqualTo(_iconImageView.RightAnchor, -16));
                AddConstraint(_titleLabel.HeightAnchor.ConstraintEqualTo(20));
    
                // Add Subtitle constraints
                AddConstraint(_subtitleLabel.TopAnchor.ConstraintEqualTo(_titleLabel.BottomAnchor, 3));
                AddConstraint(_subtitleLabel.LeftAnchor.ConstraintEqualTo(LeftAnchor, 16));
                AddConstraint(_subtitleLabel.RightAnchor.ConstraintEqualTo(_iconImageView.RightAnchor, -16));
                AddConstraint(_subtitleLabel.HeightAnchor.ConstraintEqualTo(15));
    
            }
        }
    }
