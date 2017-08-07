using System;
using ComplianceApp.iOS;
using Foundation;
using MapKit;
using UIKit;

namespace ComplianceApp.iOS
{
	public class MapDelegate : MKMapViewDelegate
	{
		protected string annotationIdentifier = "BasicAnnotation";
		UIButton detailButton;
		MapController parent;


		public MapDelegate(MapController parent)
		{
			this.parent = parent;
		}
		/// <summary>
		/// This is very much like the GetCell method on the table delegate
		/// </summary>
		public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
		{
			// try and dequeue the annotation view
			MKAnnotationView annotationView = mapView.DequeueReusableAnnotation(annotationIdentifier);
			// if we couldn't dequeue one, create a new one
			if (annotationView == null)
				annotationView = new MKPinAnnotationView(annotation, annotationIdentifier);
			else // if we did dequeue one for reuse, assign the annotation to it
				annotationView.Annotation = annotation;
			// configure our annotation view properties
			annotationView.CanShowCallout = true;
			(annotationView as MKPinAnnotationView).AnimatesDrop = true;
			(annotationView as MKPinAnnotationView).PinColor = MKPinAnnotationColor.Green;
			annotationView.Selected = true;
			// you can add an accessory view, in this case, we'll add a button on the right, and an image on the left
			detailButton = UIButton.FromType(UIButtonType.DetailDisclosure);
			detailButton.TouchUpInside += (s, e) =>
			{
				Console.WriteLine("Clicked");
				//Create Alert
				var detailAlert = UIAlertController.Create("Annotation Clicked", "You clicked on " +
					(annotation as MKAnnotation).Coordinate.Latitude.ToString() + ", " +
					(annotation as MKAnnotation).Coordinate.Longitude.ToString(), UIAlertControllerStyle.Alert);
				detailAlert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                UIWebView webView = new UIWebView();
				var url = "https://xamarin.com"; // NOTE: https secure request
				webView.LoadRequest(new NSUrlRequest(new NSUrl(url)));
                webView.Bounds = new CoreGraphics.CGRect(0, 0, 100, 100);
 
                detailAlert.Add(webView);

				parent.PresentViewController(detailAlert, true, null);
			};
			annotationView.RightCalloutAccessoryView = detailButton;
			annotationView.LeftCalloutAccessoryView = new UIImageView(UIImage.FromBundle("29_icon.png"));
			return annotationView;
		}

			// as an optimization, you should override this method to add or remove annotations as the
			// map zooms in or out.
			public override void RegionChanged(MKMapView mapView, bool animated) { }
		}
}
