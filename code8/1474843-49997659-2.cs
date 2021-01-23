    using CompApp.Customs;
    using MyApp.iOS.Renderer;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    using System.ComponentModel;
    using CoreGraphics;
    using MyApp.Views;
    using UIKit;
    using Xamarin.Forms.Internals;
    using System.Reflection;
    [assembly: ExportRenderer(typeof(SplitViewPage), typeof(SplitViewPageRenderer))]
    namespace MyApp.iOS.Renderer
    {
	public class SplitViewPageRenderer : UISplitViewController, IVisualElementRenderer, IEffectControlProvider
	{
		UIViewController _detailController;
		bool _disposed;
		EventTracker _events;
		InnerDelegate _innerDelegate;
		public static nfloat MasterWidth = 400;
		EventedViewController _masterController;
		SplitViewPage _masterDetailPage;
		bool _masterVisible;
		VisualElementTracker _tracker;
		Page PageController => Element as Page;
		Element ElementController => Element as Element;
		protected SplitViewPage MasterDetailPage => _masterDetailPage ?? (_masterDetailPage = (SplitViewPage)Element);
		public VisualElement Element { get; private set; }
		public event EventHandler<VisualElementChangedEventArgs> ElementChanged;
		UIBarButtonItem PresentButton
		{
			get { return _innerDelegate == null ? null : _innerDelegate.PresentButton; }
		}
		public UIView NativeView
		{
			get { return View; }
		}
		protected virtual void OnElementChanged(VisualElementChangedEventArgs e)
		{
			if (e.OldElement != null)
				e.OldElement.PropertyChanged -= HandlePropertyChanged;
			if (e.NewElement != null)
			{
				e.NewElement.PropertyChanged += HandlePropertyChanged;
			}
			if (UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.LandscapeLeft || UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.LandscapeRight)
			{
				PreferredDisplayMode = UISplitViewControllerDisplayMode.AllVisible;
			}
			else if (UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.Portrait || UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.PortraitUpsideDown)
			{
				PreferredDisplayMode = UISplitViewControllerDisplayMode.PrimaryOverlay;
			}
			MasterWidth = 400;
			MasterDetailPage.Master.WidthRequest = 400;
			
			MasterDetailPage.UpdateMasterBehavior();
			var changed = ElementChanged;
			if (changed != null)
				changed(this, e);
			UpdateControllers();
		}
		public SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint)
		{
			return NativeView.GetSizeRequest(widthConstraint, heightConstraint);
		}
		public void SetElement(VisualElement element)
		{
			var oldElement = Element;
			Element = element;
			ViewControllers = new[] { _masterController = new EventedViewController(), _detailController = new ChildViewController() };
			Delegate = _innerDelegate = new InnerDelegate(MasterDetailPage.MasterBehavior);
			Element.BackgroundColor = Color.Transparent;
			UpdateControllers();
			_masterController.WillAppear += MasterControllerWillAppear;
			_masterController.WillDisappear += MasterControllerWillDisappear;
			PresentsWithGesture = MasterDetailPage.IsGestureEnabled;
			OnElementChanged(new VisualElementChangedEventArgs(oldElement, element));
			EffectUtilities.RegisterEffectControlProvider(this, oldElement, element);
			if (element != null)
			{
				MethodInfo sendViewInitialized = typeof(Xamarin.Forms.Forms).GetMethod("SendViewInitialized", BindingFlags.Static | BindingFlags.NonPublic);
				sendViewInitialized?.Invoke(element, new object[] { element, NativeView });
			}
		}
		public void SetElementSize(Size size)
		{
			Element.Layout(new Rectangle(Element.X, Element.Width, size.Width, size.Height));
		}
		public UIViewController ViewController
		{
			get { return this; }
		}
		public override void ViewDidAppear(bool animated)
		{
			PageController.SendAppearing();
			base.ViewDidAppear(animated);
			ToggleMaster();
		}
		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
			PageController?.SendDisappearing();
		}
		public override void ViewDidLayoutSubviews()
		{
			if (View.Subviews.Length < 2)
				return;
			var frameBounds = View.Bounds;
			var masterBounds = _masterController.View.Frame;
			var detailsBounds = _detailController.View.Frame;
			
			nfloat statusBarHeight = UIApplication.SharedApplication.StatusBarFrame.Height;
			masterBounds.Width = 400;
			MasterWidth = (nfloat)Math.Max(MasterWidth, masterBounds.Width);
			if (Xamarin.Forms.Device.Idiom == TargetIdiom.Tablet)
			{
				bool interfaceInLandscape = UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.LandscapeLeft || UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.LandscapeRight;
				if (UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.LandscapeLeft || UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.LandscapeRight || interfaceInLandscape)
				{
					detailsBounds.X = 400;
					detailsBounds.Width = frameBounds.Width - 400;
				}
				else
				{
					detailsBounds.X = 0;
					detailsBounds.Width = frameBounds.Width;
				}
				_detailController.View.Frame = detailsBounds;
				_masterController.View.Frame = new CGRect(masterBounds.X, masterBounds.Y, masterBounds.Width, masterBounds.Height);
				if (!masterBounds.IsEmpty)
				{
					MasterDetailPage.MasterBounds = new Rectangle(masterBounds.X, masterBounds.Y, masterBounds.Width, masterBounds.Height);
				}
				if (!detailsBounds.IsEmpty)
				{
					MasterDetailPage.DetailBounds = new Rectangle(detailsBounds.X, detailsBounds.Y, detailsBounds.Width, detailsBounds.Height);
				}
				_masterController.View.SetNeedsLayout();
				_detailController.View.SetNeedsLayout();
				
			}
			else
			{
				if (!masterBounds.IsEmpty)
				{
					MasterDetailPage.MasterBounds = new Rectangle(MasterWidth, 0, MasterWidth, masterBounds.Height);
				}
				if (!detailsBounds.IsEmpty)
				{
					MasterDetailPage.DetailBounds = new Rectangle(0, 0, detailsBounds.Width, detailsBounds.Height);
				}
			}
			
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			UpdateBackground();
			UpdateFlowDirection();
			_tracker = new VisualElementTracker(this);
			_events = new EventTracker(this);
			_events.LoadEvents(NativeView);
		}
		public override void ViewWillDisappear(bool animated)
		{
			if (_masterVisible)
				PerformButtonSelector();
			base.ViewWillDisappear(animated);
		}
		public override void ViewWillLayoutSubviews()
		{
			base.ViewWillLayoutSubviews();
			_masterController.View.BackgroundColor = UIColor.White;
			CGRect bounds = _masterController.View.Bounds;
			CGRect frame = _masterController.View.Frame;
			(this.ViewController as UISplitViewController).MinimumPrimaryColumnWidth = 400;
			(this.ViewController as UISplitViewController).MaximumPrimaryColumnWidth = 400;
		}
		public override void WillRotate(UIInterfaceOrientation toInterfaceOrientation, double duration)
		{
			// On IOS8 the MasterViewController ViewAppear/Disappear weren't being called correctly after rotation 
			// We now close the Master by using the new SplitView API, basicly we set it to hidden and right back to the Normal/AutomaticMode
			if (!MasterDetailPage.ShouldShowSplitMode && _masterVisible)
			{
				MasterDetailPage.CanChangeIsPresented = true;
				PreferredDisplayMode = UISplitViewControllerDisplayMode.PrimaryHidden;
				PreferredDisplayMode = UISplitViewControllerDisplayMode.Automatic;
			}
			var masterBounds = _masterController.View.Frame;
			MessagingCenter.Send<IVisualElementRenderer>(this,  "Xamarin.UpdateToolbarButtons");
			MasterDetailPage.UpdateMasterBehavior();
			base.WillRotate(toInterfaceOrientation, duration);
		}
		public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
		{
			base.DidRotate(fromInterfaceOrientation);
			var masterBounds = _masterController.View.Frame;
			MasterWidth = (nfloat)Math.Max(MasterWidth, masterBounds.Width);
			if (!masterBounds.IsEmpty)
			{
				MasterDetailPage.MasterBounds = new Rectangle(MasterWidth, 0, MasterWidth, masterBounds.Height);
			}
		}
		public override UIViewController ChildViewControllerForStatusBarHidden()
		{
			if (((MasterDetailPage)Element).Detail != null)
				return (UIViewController)Platform.GetRenderer(((MasterDetailPage)Element).Detail);
			else
				return base.ChildViewControllerForStatusBarHidden();
		}
		void ClearControllers()
		{
			foreach (var controller in _masterController.ChildViewControllers)
			{
				controller.View.RemoveFromSuperview();
				controller.RemoveFromParentViewController();
			}
			foreach (var controller in _detailController.ChildViewControllers)
			{
				controller.View.RemoveFromSuperview();
				controller.RemoveFromParentViewController();
			}
		}
		void HandleMasterPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == Page.IconProperty.PropertyName || e.PropertyName == Page.TitleProperty.PropertyName)
				MessagingCenter.Send<IVisualElementRenderer>(this, "Xamarin.UpdateToolbarButtons");
		}
		void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (_tracker == null)
				return;
			if (e.PropertyName == "Master" || e.PropertyName == "Detail")
				UpdateControllers();
			else if (e.PropertyName == Xamarin.Forms.MasterDetailPage.IsPresentedProperty.PropertyName)
				ToggleMaster();
			else if (e.PropertyName == Xamarin.Forms.MasterDetailPage.IsGestureEnabledProperty.PropertyName)
				base.PresentsWithGesture = this.MasterDetailPage.IsGestureEnabled;
			else if (e.PropertyName == "FlowDirection")
				UpdateFlowDirection();
			MessagingCenter.Send<IVisualElementRenderer>(this, "Xamarin.UpdateToolbarButtons");
		}
		void MasterControllerWillAppear(object sender, EventArgs e)
		{
			_masterVisible = true;
			if (MasterDetailPage.CanChangeIsPresented)
				ElementController.SetValueFromRenderer(Xamarin.Forms.MasterDetailPage.IsPresentedProperty, true);
		}
		void MasterControllerWillDisappear(object sender, EventArgs e)
		{
			_masterVisible = false;
			if (MasterDetailPage.CanChangeIsPresented)
				ElementController.SetValueFromRenderer(Xamarin.Forms.MasterDetailPage.IsPresentedProperty, false);
		}
		void PerformButtonSelector()
		{
			DisplayModeButtonItem.Target.PerformSelector(DisplayModeButtonItem.Action, DisplayModeButtonItem, 0);
		}
		void ToggleMaster()
		{
			if (_masterVisible == MasterDetailPage.IsPresented || MasterDetailPage.ShouldShowSplitMode)
				return;
			PerformButtonSelector();
		}
		void UpdateBackground()
		{
			if (!string.IsNullOrEmpty(((Page)Element).BackgroundImage))
				View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromBundle(((Page)Element).BackgroundImage));
			else if (Element.BackgroundColor == Color.Default)
				View.BackgroundColor = UIColor.White;
			else
				View.BackgroundColor = Element.BackgroundColor.ToUIColor();
		}
		void UpdateControllers()
		{
			MasterDetailPage.Master.PropertyChanged -= HandleMasterPropertyChanged;
			if (Platform.GetRenderer(MasterDetailPage.Master) == null)
				Platform.SetRenderer(MasterDetailPage.Master, Platform.CreateRenderer(MasterDetailPage.Master));
			if (Platform.GetRenderer(MasterDetailPage.Detail) == null)
				Platform.SetRenderer(MasterDetailPage.Detail, Platform.CreateRenderer(MasterDetailPage.Detail));
			ClearControllers();
			MasterDetailPage.Master.PropertyChanged += HandleMasterPropertyChanged;
			var master = Platform.GetRenderer(MasterDetailPage.Master).ViewController;
			var detail = Platform.GetRenderer(MasterDetailPage.Detail).ViewController;
			_masterController.View.AddSubview(master.View);
			_masterController.AddChildViewController(master);
			_detailController.View.AddSubview(detail.View);
			_detailController.AddChildViewController(detail);
		}
		void UpdateFlowDirection()
		{
			bool ios9orLater = UIDevice.CurrentDevice.CheckSystemVersion(9, 0);
			if (NativeView == null || View == null || !ios9orLater)
				return;
			View.SemanticContentAttribute = UISemanticContentAttribute.ForceLeftToRight;
		}
		class InnerDelegate : UISplitViewControllerDelegate
		{
			readonly MasterBehavior _masterPresentedDefaultState;
			public InnerDelegate(MasterBehavior masterPresentedDefaultState)
			{
				_masterPresentedDefaultState = masterPresentedDefaultState;
			}
			public UIBarButtonItem PresentButton { get; set; }
			public override bool ShouldHideViewController(UISplitViewController svc, UIViewController viewController, UIInterfaceOrientation inOrientation)
			{
				bool willHideViewController;
				switch (_masterPresentedDefaultState)
				{
					case MasterBehavior.Split:
						willHideViewController = false;
						break;
					case MasterBehavior.Popover:
						willHideViewController = true;
						break;
					case MasterBehavior.SplitOnPortrait:
						willHideViewController = !(inOrientation == UIInterfaceOrientation.Portrait || inOrientation == UIInterfaceOrientation.PortraitUpsideDown);
						break;
					default:
						willHideViewController = inOrientation == UIInterfaceOrientation.Portrait || inOrientation == UIInterfaceOrientation.PortraitUpsideDown;
						break;
				}
				return willHideViewController;
			}
			public override void WillHideViewController(UISplitViewController svc, UIViewController aViewController, UIBarButtonItem barButtonItem, UIPopoverController pc)
			{
				PresentButton = barButtonItem;
			}
		}
		void IEffectControlProvider.RegisterEffect(Effect effect)
		{
			VisualElementRenderer<VisualElement>.RegisterEffect(effect, View);
		}
		protected override void Dispose(bool disposing)
		{
			if (_disposed)
			{
				return;
			}
			_disposed = true;
			if (disposing)
			{
				if (Element != null)
				{
					PageController.SendDisappearing();
					Element.PropertyChanged -= HandlePropertyChanged;
					if (MasterDetailPage?.Master != null)
					{
						MasterDetailPage.Master.PropertyChanged -= HandleMasterPropertyChanged;
					}
					Element = null;
				}
				if (_tracker != null)
				{
					_tracker.Dispose();
					_tracker = null;
				}
				if (_events != null)
				{
					_events.Dispose();
					_events = null;
				}
				if (_masterController != null)
				{
					_masterController.WillAppear -= MasterControllerWillAppear;
					_masterController.WillDisappear -= MasterControllerWillDisappear;
				}
				ClearControllers();
			}
			base.Dispose(disposing);
		}
	}
	internal class ChildViewController : UIViewController
	{
		public override void ViewDidLayoutSubviews()
		{
			foreach (var vc in ChildViewControllers)
			{
				CGRect rect = View.Bounds;
				vc.View.Frame = rect;
			}
		}
	}
	internal class EventedViewController : ChildViewController
	{
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			var eh = WillAppear;
			if (eh != null)
				eh(this, EventArgs.Empty);
		}
		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			var eh = WillDisappear;
			if (eh != null)
				eh(this, EventArgs.Empty);
		}
		public override void ViewDidLayoutSubviews()
		{
			CGRect rect = View.Bounds;
			View.Bounds = rect;
			foreach (var vc in ChildViewControllers)
			{
				rect = vc.View.Frame;
				vc.View.Frame = rect;
				rect = vc.View.Bounds;
				vc.View.Bounds = rect;
			}
		}
		public event EventHandler WillAppear;
		public event EventHandler WillDisappear;
	}
    }
