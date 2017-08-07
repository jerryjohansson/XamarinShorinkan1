using System;

using UIKit;
using PortableShareLibrary;
using Foundation;

namespace ComplianceApp.iOS
{
	public partial class TestViewController : UIViewController
	{
		public string argument = null;
		public string url = null;

		public TestViewController()
		{
		}

		public TestViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.



			string fileName = "Content/chart2.html"; // remember case sensitive
			string localHtmlUrl = System.IO.Path.Combine(NSBundle.MainBundle.BundlePath, fileName);
			webView.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrl, false)));
			webView.ScalesPageToFit = true;
			webView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;

			if (argument == "goto://Test1")
			{
			}
			else if (argument == "goto://Test2")
			{ 
			
			}


		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

