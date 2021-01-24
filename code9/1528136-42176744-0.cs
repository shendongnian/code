    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    using Windows.UI.Popups; //This is used for massage box within a blank applocation. 
    
    using Windows.UI.Xaml.Media.Animation;
    
    // The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237
    
    namespace Save_The_Humans
    {
    	/// <summary>
    	/// A basic page that provides characteristics common to most applications.
    	/// </summary>
    	public sealed partial class MainPage : Save_The_Humans.Common.LayoutAwarePage
    	{
    		Random random = new Random();
    		DispatcherTimer enemyTimer = new DispatcherTimer();
    		DispatcherTimer tagetTimer = new DispatcherTimer();
    		bool humanCaptured = false;
    
    		public MainPage()
    		{
    			this.InitializeComponent();
    
    			enemyTimer.Tick += enemyTimer_Tick;
    			enemyTimer.Interval = TimeSpan.FromSeconds(2);
    
    			tagetTimer.Tick += tagetTimer_Tick;
    			tagetTimer.Interval = TimeSpan.FromSeconds(.1);
    		}
    
    		void tagetTimer_Tick(object sender, object e)
    		{
    			progressBar.Value += 1;
    			if (progressBar.Value >= progressBar.Maximum)
    				EndTheGame();
    			
    		}
    
    		private void EndTheGame()
    		{
    			if (!playArea.Children.Contains(gameOverText))
    			{
    				enemyTimer.Stop();
    				tagetTimer.Stop();
    				humanCaptured = false;
    				startButton.Visibility = Visibility.Visible;
    				playArea.Children.Add(gameOverText);
    			}
    		}
    
    		void enemyTimer_Tick(object sender, object e)
    		{
    			AddEnemy();
    		}
    
    		/// <summary>
    		/// Populates the page with content passed during navigation.  Any saved state is also
    		/// provided when recreating a page from a prior session.
    		/// </summary>
    		/// <param name="navigationParameter">The parameter value passed to
    		/// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
    		/// </param>
    		/// <param name="pageState">A dictionary of state preserved by this page during an earlier
    		/// session.  This will be null the first time a page is visited.</param>
    		protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
    		{
    		}
    
    		/// <summary>
    		/// Preserves state associated with this page in case the application is suspended or the
    		/// page is discarded from the navigation cache.  Values must conform to the serialization
    		/// requirements of <see cref="SuspensionManager.SessionState"/>.
    		/// </summary>
    		/// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
    		protected override void SaveState(Dictionary<String, Object> pageState)
    		{
    		}
    		private void startButton_Click(object sender, RoutedEventArgs e)
    		{
    			StartGame();
    		}
    		/// <summary>
    		/// Starts the game.
    		/// </summary>
    		public void StartGame()
    		{
    			human.IsHitTestVisible = true;
    			humanCaptured = false;
    			progressBar.Value = 0;
    			startButton.Visibility = Visibility.Collapsed;
    			/*playArea.Children.Add(target);
    			playArea.Children.Add(human);*/
    			enemyTimer.Start();
    			tagetTimer.Start();
    		}
    		/// <summary>
    		/// Starts the animation, below is the enemy method.
    		/// </summary>
    		private void AddEnemy()
    		{
    			ContentControl enemy = new ContentControl();
    			enemy.Template = Resources["EnemyTemplate"] as ControlTemplate;
    			AnimateEnemy(enemy, 0, playArea.ActualWidth - 100, "(Canvas.Left)");
    			AnimateEnemy(enemy, random.Next((int)playArea.ActualHeight - 100),
    				random.Next((int)playArea.ActualHeight - 100), "(Canvas.Top)");
    			playArea.Children.Add(enemy);
    		}
    
    		private void AnimateEnemy(ContentControl enemy, double from, double to, string properyToAnimate)
    		{
    			Storyboard storyboard = new Storyboard() { AutoReverse = true, RepeatBehavior = RepeatBehavior.Forever };
    			DoubleAnimation animation = new DoubleAnimation()
    			{
    				From = from,
    				To = to,
    				Duration = new Duration(TimeSpan.FromSeconds(random.Next(4, 6)))
    			};
    			Storyboard.SetTarget(animation, enemy);
    			Storyboard.SetTargetProperty(animation, properyToAnimate);
    			storyboard.Children.Add(animation);
    			storyboard.Begin();
    		}
    		/// <summary>
    		/// async needs to be a part of the method to show message box!
    		/// </summary>
    		/// <param name="sender"></param>
    		/// <param name="e"></param>
    		private async void About_Click(object sender, RoutedEventArgs e)
    		{
    			//Creating instance for the MessageDialog Class  
    			//and passing the message in it's Constructor
    			MessageDialog msgbox = new MessageDialog("Created by");
    			//Calling the Show method of MessageDialog class  
    			//which will show the MessageBox  
    			await msgbox.ShowAsync();
    		}
    	}
    }
