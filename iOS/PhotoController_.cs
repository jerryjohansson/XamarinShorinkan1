using Foundation;
using System;
using UIKit;
using CoreGraphics;
using System.Drawing;
using AssetsLibrary;

namespace ComplianceApp.iOS
{
	public partial class PhotoController : UIViewController
	{
		UIRotationGestureRecognizer rotateGesture;
		UIPanGestureRecognizer panGesture;

		UIImagePickerController imagePicker;
		UIButton choosePhotoButton;
		UIButton horizPhotoButton;
		UIImageView imageView;
		UIButton savePhotoButton;
		UIImage combinedImage;
		UIImageView combinedImageView;
		bool isPortrait = true;
		CGSize newSize = new CGSize(0, 0);

		public PhotoController(IntPtr handle) : base(handle)
        {
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			nfloat r = 0;
			nfloat dx = 0;
			nfloat dy = 0;

			Title = "Choose Photo";
			View.BackgroundColor = UIColor.White;


			//imageView = new UIImageView(new CGRect(1, 1, (int)UIScreen.MainScreen.Bounds.Width, (int)UIScreen.MainScreen.Bounds.Height
			//                                      ));

			//imageView = new UIImageView(new CGRect(1, 1, (int)UIScreen.MainScreen.Bounds.Width, 230//(int)UIScreen.MainScreen.Bounds.Height
			//                                    ));
			imageView = new UIImageView(new CGRect(1, 1, 100, 100
												));

			using (var image = UIImage.FromFile("Content/Images/shorinkan.png"))
			{
				imageView = new UIImageView(image) { Frame = new CoreGraphics.CGRect(new PointF(0, 0), new CGSize(100, 100)) };
				imageView.UserInteractionEnabled = true;
				View.AddSubview(imageView);
			}



			choosePhotoButton = UIButton.FromType(UIButtonType.RoundedRect);
			choosePhotoButton.Frame = new CGRect(10, 80, 100, 40);
			choosePhotoButton.SetTitle("Portrait", UIControlState.Normal);
			choosePhotoButton.TouchUpInside += (s, e) =>
			{
				//Add(imageView);

				// create a new picker controller
				imagePicker = new UIImagePickerController();

				// set our source to the photo library
				imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;

				// set what media types
				imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);

				imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
				imagePicker.Canceled += Handle_Canceled;

				isPortrait = true;
                imagePicker.ModalPresentationStyle = UIModalPresentationStyle.Popover;
				// show the picker
                PresentViewController(imagePicker, true, null);


			};
			View.Add(choosePhotoButton);

			horizPhotoButton = UIButton.FromType(UIButtonType.RoundedRect);
			horizPhotoButton.Frame = new CGRect(100, 80, 100, 40);
			horizPhotoButton.SetTitle("Horizontal", UIControlState.Normal);
			horizPhotoButton.TouchUpInside += (s, e) =>
			{

				// testing changing for horizontal pic
				//imageView.Bounds = new CGRect(0, 0, (int)UIScreen.MainScreen.Bounds.Width, 220);
				//Add(imageView);

				// create a new picker controller
				imagePicker = new UIImagePickerController();

				// set our source to the photo library
				imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;

				// set what media types
				imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);

				imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
				imagePicker.Canceled += Handle_Canceled;

				// show the picker
				imagePicker.ModalPresentationStyle = UIModalPresentationStyle.Popover;
				// show the picker
				PresentViewController(imagePicker, true, null);
				isPortrait = false;

			};
			View.Add(horizPhotoButton);

			savePhotoButton = UIButton.FromType(UIButtonType.RoundedRect);
			savePhotoButton.Frame = new CGRect(200, 80, 100, 40);
			savePhotoButton.SetTitle("Save", UIControlState.Normal);
			savePhotoButton.TouchUpInside += (s, e) =>
			{
				choosePhotoButton.Hidden = true;
				horizPhotoButton.Hidden = true;
				savePhotoButton.Hidden = true;
                backButton.Hidden = true;

				UIGraphics.BeginImageContext(newSize); // Use this call
				View.DrawViewHierarchy(View.Frame, true);
				UIImage image3 = UIGraphics.GetImageFromCurrentImageContext();
				UIGraphics.EndImageContext();

				image3.SaveToPhotosAlbum((image, error) =>
				  {
					  var o = image as UIImage;
					  Console.WriteLine("error:" + error);
				  });
				UIGraphics.EndImageContext();

				choosePhotoButton.Hidden = false;
				horizPhotoButton.Hidden = false;
				savePhotoButton.Hidden = false;
                backButton.Hidden = false;


			};
			View.Add(savePhotoButton);







			rotateGesture = new UIRotationGestureRecognizer(() =>
			{
				if ((rotateGesture.State == UIGestureRecognizerState.Began || rotateGesture.State == UIGestureRecognizerState.Changed) && (rotateGesture.NumberOfTouches == 2))
				{

					imageView.Transform = CGAffineTransform.MakeRotation(rotateGesture.Rotation + r);
				}
				else if (rotateGesture.State == UIGestureRecognizerState.Ended)
				{
					r += rotateGesture.Rotation;
				}
			});

			panGesture = new UIPanGestureRecognizer(() =>
			{
				if ((panGesture.State == UIGestureRecognizerState.Began || panGesture.State == UIGestureRecognizerState.Changed) && (panGesture.NumberOfTouches == 1))
				{

					var p0 = panGesture.LocationInView(View);

					if (dx == 0)
						dx = p0.X - imageView.Center.X;

					if (dy == 0)
						dy = p0.Y - imageView.Center.Y;

					var p1 = new CGPoint(p0.X - dx, p0.Y - dy);

					imageView.Center = p1;
				}
				else if (panGesture.State == UIGestureRecognizerState.Ended)
				{
					dx = 0;
					dy = 0;
				}
			});


			imageView.AddGestureRecognizer(panGesture);
			imageView.AddGestureRecognizer(rotateGesture);

		}


		// Do something when the
		void Handle_Canceled(object sender, EventArgs e)
		{
			Console.WriteLine("picker cancelled");
			imagePicker.DismissModalViewController(true);
		}

		// This is a sample method that handles the FinishedPickingMediaEvent
		protected void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
		{
			// determine what was selected, video or image
			bool isImage = false;
			switch (e.Info[UIImagePickerController.MediaType].ToString())
			{
				case "public.image":
					Console.WriteLine("Image selected");
					isImage = true;
					break;

				case "public.video":
					Console.WriteLine("Video selected");
					break;
			}

			Console.Write("Reference URL: [" + UIImagePickerController.ReferenceUrl + "]");

			// get common info (shared between images and video)
			NSUrl referenceURL = e.Info[new NSString("UIImagePickerControllerReferenceUrl")] as NSUrl;
			if (referenceURL != null)
				Console.WriteLine(referenceURL.ToString());

			// if it was an image, get the other image info
			if (isImage)
			{

				// get the original image
				UIImage originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
				if (originalImage != null)
				{
					// do something with the image
					Console.WriteLine("got the original image");

					if (isPortrait)
						newSize = new CGSize((int)UIScreen.MainScreen.Bounds.Width, (int)UIScreen.MainScreen.Bounds.Height);
					else
						newSize = new CGSize((int)UIScreen.MainScreen.Bounds.Height, (int)UIScreen.MainScreen.Bounds.Width);

					originalImage = originalImage.Scale(newSize);
					this.View.BackgroundColor = UIColor.FromPatternImage(originalImage);
					//UIImage shorinkan = UIImage.FromFile("Images/Shorinkan.png");
					//imageView.Image = shorinkan;


				}




			}
			// if it's a video
			else
			{
				// get video url
				NSUrl mediaURL = e.Info[UIImagePickerController.MediaURL] as NSUrl;
				if (mediaURL != null)
				{
					//
					Console.WriteLine(mediaURL.ToString());
				}
			}

			// dismiss the picker
			imagePicker.DismissModalViewController(true);
		}



		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}