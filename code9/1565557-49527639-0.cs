	/* * Created by SharpDevelop. 
	   * User: sravanth 
	   * Date: 2/2/2018 
	   * Time: 1:33 AM * 
	   * To change this template use Tools | Options | Coding | Edit Standard Headers. 
	*/ 
	using System; 
	using OpenQA.Selenium; 
	using OpenQA.Selenium.Chrome; 
	using OpenQA.Selenium.IE; 
	using OpenQA.Selenium.Support.UI; 
	using System.Diagnostics; 
	using Microsoft.VisualBasic; 
	using System.Windows.Forms; 
	using System.Runtime.InteropServices; 
	//using System.Collections; 
	using System.Collections.Generic; 
	namespace sele 
	{ 
		class Program 
		{ 
			public static void Main(string[] args) 
			{ 
				//Console.WriteLine("Hello World!"); 
				// TODO: Implement Functionality Here 
				//Console.Write("Press any key to continue . . . "); 
				//Console.ReadKey(true); 
				//System.setProperty("webdriver.ie.driver", "C:\\Users/sravanth/Downloads/IEDriverServer_x64_3.8.0/IEdriver.exe"); 
				// C:\Users\sravanth\Downloads\IEDriverServer_x64_3.8.0 
				IWebDriver driver;
				// = new InternetExplorerDriver(@"C:\\Users/sravanth/Downloads/IEDriverServer_x64_3.8.0"); 
				var service = InternetExplorerDriverService.CreateDefaultService(@"C:\\Users/sravanth/Downloads/IEDriverServer_x64_3.8.0"); 
				//var service = InternetExplorerDriverService.CreateDefaultService(@"C:\\Users/sravanth/Downloads/chromedriver_win32"); 
				// properties on the service can be used to e.g. hide the command prompt 
				var options = new InternetExplorerOptions { IgnoreZoomLevel = true, InitialBrowserUrl = "file:///C:/Users/sravanth/Desktop/a.html", IntroduceInstabilityByIgnoringProtectedModeSettings = true }; 
				driver = new InternetExplorerDriver(service, options); 
				//driver = new ChromeDriver(@"C:\\Users/sravanth/Downloads/chromedriver_win32"); 
				//driver.Navigate().GoToUrl("https://www.w3schools.com/js/tryit.asp?filename=tryjs_prompt"); 
				driver.Url="file:///C:/Users/sravanth/Desktop/a.html"; 
				//driver.Navigate().GoToUrl("file:///C:/Users/sravanth/Desktop/a.html"); 
				driver.Navigate(); 
				//IList links = driver.FindElements(By.TagName("button")); 
				// Console.WriteLine(links.Count); 
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); 
				//IWebElement btn = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btn"))); 
				IWebElement btn=driver.FindElement(By.Id("btn")); 
				btn.Click(); 
				// System.Threading.Thread.Sleep(5000); 
				Process[] processes = Process.GetProcessesByName("iexplore"); 
				Console.WriteLine(processes.Length); 
				int i=0; 
				IntPtr windowHandle; 
				foreach (Process p in processes) 
				{ 
					i=i+1; 
					Console.WriteLine(i); 
					windowHandle = p.MainWindowHandle; 
					Console.Write("iexplore"); 
					Console.WriteLine(windowHandle.ToString()); 
					// do something with windowHandle 
					if(i.Equals(1))
					{ 
						//Console.WriteLine("Reached If Loop"); 
						SetForegroundWindow(windowHandle); 
					} 
				} 
				//System.Windows.Forms.SendKeys.SendWait("%{F4}"); 
				Console.WriteLine(processes.Length); 
				Process.Start("notepad.exe"); 
				var prc = Process.GetProcessesByName("notepad"); 
				if (prc.Length > 0) 
				{ 
					SetForegroundWindow(prc[0].MainWindowHandle); 
				} 
				//System.Windows.Forms.SendKeys.SendWait("%{F4}"); 
			} 
			
			[DllImport("user32.dll")] 
			private static extern bool SetForegroundWindow(IntPtr hWnd); 
		} 
	}  
