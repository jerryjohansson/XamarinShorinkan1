using System;
using Foundation;
using UIKit;

namespace ComplianceApp.iOS
{
	public class YourWebViewDelegate : UIWebViewDelegate
	{
		UIViewController CurrentInstance;
		public string MyRequestURL = null;

		public YourWebViewDelegate(UIViewController _currentInstance)
		{
			CurrentInstance = _currentInstance;
		}



		public override bool ShouldStartLoad(UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
		{
			if (navigationType == UIWebViewNavigationType.LinkClicked)
			{
				this.MyRequestURL = request.Url.ToString();
				if(request.Url.ToString() == "goto://Test1")
					CurrentInstance.PerformSegue("mySegueTest1", this);
				else if (request.Url.ToString() == "goto://Test2")
					CurrentInstance.PerformSegue("mySegueTest2", this);
			}
			return true;
		}
	}
}
