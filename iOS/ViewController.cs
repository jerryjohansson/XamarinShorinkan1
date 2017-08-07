using System;
using System.IO;
using CoreGraphics;
using CoreLocation;
using Foundation;
using Google.Maps;
using MapKit;
using UIKit;



namespace ComplianceApp.iOS
{
	public partial class ViewController : UIViewController
	{
		const string MapsApiKey = "AIzaSyB5xmC39gtPJiyj9GWYocAJj31m82gO5Vs";
		public static string clickedLink = null;
		YourWebViewDelegate viewDelegate = null;

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Perform any additional setup after loading the view, typically from a nib.
			MapInit();

			string fileName = "Content/chart.html"; // remember case sensitive
			string localHtmlUrl = System.IO.Path.Combine(NSBundle.MainBundle.BundlePath, fileName);
			webView.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrl, false)));
			webView.ScalesPageToFit = true;
			webView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;


			//string testHTML = "<html>  <head></head>  <body>  <div> <a href='goto://Test1'>TEST 1</a> <br/> <a href='goto://Test2'>TEST 2</a>  </div>   </body><script language='javascript'>function basicAlert() { alert('Hello, World!');}</script>    </html>";
			//myWebView.LoadHtmlString(testHTML, null);


			//fileName = "Content/LinkAction.html"; // remember case sensitive
			//localHtmlUrl = System.IO.Path.Combine(NSBundle.MainBundle.BundlePath, fileName);
			//myWebView.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrl, false)));
			//myWebView.ScalesPageToFit = true;
			//myWebView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;




			viewDelegate = new YourWebViewDelegate(this);
			webView.Delegate = viewDelegate;
			//myWebView.Delegate = viewDelegate;
			//btnObligation.Clicked += OnCallJavaScriptButtonClicked;


		}


		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			//if (segue.Identifier == null)
			//	return;

			//// do first a control on the Identifier for your segue
			//if (segue.Identifier.Equals("mySegueTest1"))
			//{
			//	var myData = (TestViewController)segue.DestinationViewController;
			//	myData.argument = viewDelegate.MyRequestURL;
			//}
			//else if (segue.Identifier.Equals("mySegueTest2"))
			//{ 
			//	var myData = (TestViewController2)segue.DestinationViewController;
			//	myData.argument = viewDelegate.MyRequestURL;
			
			//}
		}





		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}

		public void MapInit()
		{ 
			MapServices.ProvideAPIKey(MapsApiKey);

			//myMapView = new MKMapView(UIScreen.MainScreen.Bounds);
			myMapView.ZoomEnabled = true;
			myMapView.ScrollEnabled = true;

			myMapView.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
			CLLocationCoordinate2D coords = new CLLocationCoordinate2D(26.2402577, 127.685999);
			MKCoordinateSpan span = new MKCoordinateSpan(KilometresToLatitudeDegrees(130), KilometresToLongitudeDegrees(130, coords.Latitude));
			myMapView.Region = new MKCoordinateRegion(coords, span);

			MKPointAnnotation perthAnno = new MKPointAnnotation();
			perthAnno.Title = "Dojo";
            perthAnno.Subtitle = "Aja 264 Naha";
			perthAnno.Coordinate = new CLLocationCoordinate2D(26.2402577, 127.685999);

			myMapView.AddAnnotation(perthAnno);



		}


		public double KilometresToLatitudeDegrees(double kms)
		{
			double earthRadius = 6371.0; // in kms
			double radiansToDegrees = 180.0 / Math.PI;
			return (kms / earthRadius) * radiansToDegrees;
		}


		public double KilometresToLongitudeDegrees(double kms, double atLatitude)
		{
			double earthRadius = 6371.0; // in kms
			double degreesToRadians = Math.PI / 180.0;
			double radiansToDegrees = 180.0 / Math.PI;
			// derive the earth's radius at that point in latitude
			double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);
			return (kms / radiusAtLatitude) * radiansToDegrees;
		}
	}
}
