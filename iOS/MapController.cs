using System;
using CoreLocation;
using Google.Maps;
using MapKit;
using UIKit;

namespace ComplianceApp.iOS
{
	public partial class MapController : UIViewController
	{


        const string MapsApiKey = "AIzaSyB5xmC39gtPJiyj9GWYocAJj31m82gO5Vs";

		public MapController(IntPtr handle) : base(handle)
		{
		}


		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
            MapInit();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}


		public void MapInit()
		{
			MapServices.ProvideAPIKey(MapsApiKey);

            allMapView.Delegate = new MapDelegate(this);

			//myMapView = new MKMapView(UIScreen.MainScreen.Bounds);
            allMapView.ZoomEnabled = true;
			allMapView.ScrollEnabled = true;

			allMapView.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
			CLLocationCoordinate2D coords = new CLLocationCoordinate2D(0.2402577, 0.685999);
			MKCoordinateSpan span = new MKCoordinateSpan(KilometresToLatitudeDegrees(20000), KilometresToLongitudeDegrees(20000, coords.Latitude));
			allMapView.Region = new MKCoordinateRegion(coords, span);

            var Anno1 = new BasicMapAnnotation(new CLLocationCoordinate2D(26.2402577, 127.685999), "Nakazato's Dojo", "Aja 264 Naha");
			//Anno1.Title = "Nakazato's Dojo";
			//Anno1.Subtitle = "Aja 264 Naha";
			//Anno1.Coordinate = new CLLocationCoordinate2D(26.2402577, 127.685999);

			MKPointAnnotation Anno2 = new MKPointAnnotation();
			Anno2.Title = "Barnes Shorin-ryu";
			Anno2.Subtitle = "Perth";
			Anno2.Coordinate = new CLLocationCoordinate2D(-31.9, 115.8);

			MKPointAnnotation Anno3 = new MKPointAnnotation();
			Anno3.Title = "Shorinkan Shorin-Ryu";
			Anno3.Subtitle = "Collaroy, NSW";
			Anno3.Coordinate = new CLLocationCoordinate2D(-33.734351, 151.302045);

			MKPointAnnotation Anno4 = new MKPointAnnotation();
			Anno4.Title = "Shorinryu Shorinkan";
			Anno4.Subtitle = "Nottingham";
			Anno4.Coordinate = new CLLocationCoordinate2D(52.923099, -1.145621);

			MKPointAnnotation Anno5 = new MKPointAnnotation();
			Anno5.Title = "Axsom Martial Arts";
			Anno5.Subtitle = "USA";
			Anno5.Coordinate = new CLLocationCoordinate2D(37.0411616, -76.47067019999997 );

			MKPointAnnotation Anno6 = new MKPointAnnotation();
			Anno6.Title = "4 Kicks Karate";
			Anno6.Subtitle = "Canada";
			Anno6.Coordinate = new CLLocationCoordinate2D(43.16403409999999, -77.48626869999998);

			MKPointAnnotation Anno7 = new MKPointAnnotation();
			Anno7.Title = "Bushido Martial Art";
			Anno7.Subtitle = "Canada";
			Anno7.Coordinate = new CLLocationCoordinate2D(43.70659430000001, -80.35966050000002);

			MKPointAnnotation Anno8 = new MKPointAnnotation();
			Anno8.Title = "Roberts Karate";
			Anno8.Subtitle = "Canada";
			Anno8.Coordinate = new CLLocationCoordinate2D(43.5000387, -80.213773);

			MKPointAnnotation Anno9 = new MKPointAnnotation();
			Anno9.Title = "Ferraro Karate";
			Anno9.Subtitle = "Canada";
            Anno9.Coordinate = new CLLocationCoordinate2D(43.5470921, -80.24968560000002);

			MKPointAnnotation Anno10 = new MKPointAnnotation();
			Anno10.Title = "New York Shorinkan Karate";
			Anno10.Subtitle = "USA";
			Anno10.Coordinate = new CLLocationCoordinate2D(40.8438401, -72.99759489999997);

			MKPointAnnotation Anno11 = new MKPointAnnotation();
			Anno11.Title = "Shorin Ryu Minnesota";
			Anno11.Subtitle = "USA";
			Anno11.Coordinate = new CLLocationCoordinate2D(45.016101, -93.219791);

			MKPointAnnotation Anno12 = new MKPointAnnotation();
			Anno12.Title = "Shorinkan Family Karate";
			Anno12.Subtitle = "USA";
			Anno12.Coordinate = new CLLocationCoordinate2D(38.4419419, -105.23708210000001);

			MKPointAnnotation Anno13 = new MKPointAnnotation();
			Anno13.Title = "American Martial Arts Institute";
			Anno13.Subtitle = "USA";
			Anno13.Coordinate = new CLLocationCoordinate2D(43.22466989999999, -85.55118149999998);

			MKPointAnnotation Anno14 = new MKPointAnnotation();
			Anno14.Title = "Atsugi City Dojo";
			Anno14.Subtitle = "Japan";
			Anno14.Coordinate = new CLLocationCoordinate2D(35.4430818, 139.36248890000002);

			MKPointAnnotation Anno15 = new MKPointAnnotation();
			Anno15.Title = "Authentic Ancient Arts";
			Anno15.Subtitle = "USA";
			Anno15.Coordinate = new CLLocationCoordinate2D(43.010751, -88.23339499999997);

			MKPointAnnotation Anno16 = new MKPointAnnotation();
			Anno16.Title = "Bethea's Karate Studio";
			Anno16.Subtitle = "";
			Anno16.Coordinate = new CLLocationCoordinate2D(40.4862219, -86.13209440000003);

			MKPointAnnotation Anno17 = new MKPointAnnotation();
			Anno17.Title = "C.D. Williamson Karate";
			Anno17.Subtitle = "USA";
			Anno17.Coordinate = new CLLocationCoordinate2D(30.51569, -86.46635300000003);

			MKPointAnnotation Anno18 = new MKPointAnnotation();
			Anno18.Title = "Crawfordsville School of Karate";
			Anno18.Subtitle = "USA";
			Anno18.Coordinate = new CLLocationCoordinate2D(40.0419013, -86.90259209999999);

			MKPointAnnotation Anno19 = new MKPointAnnotation();
			Anno19.Title = "Donnie Michael’s Karate";
			Anno19.Subtitle = "USA";
			Anno19.Coordinate = new CLLocationCoordinate2D(40.4412163, -86.12439369999998);

			MKPointAnnotation Anno20 = new MKPointAnnotation();
			Anno20.Title = "East Coast Karate";
			Anno20.Subtitle = "USA";
			Anno20.Coordinate = new CLLocationCoordinate2D(41.5133815, -71.68829189999997);

			MKPointAnnotation Anno21 = new MKPointAnnotation();
			Anno21.Title = "Eggleston's Karate Studio";
			Anno21.Subtitle = "USA";
			Anno21.Coordinate = new CLLocationCoordinate2D(37.5074744, -77.5832929);

			MKPointAnnotation Anno22 = new MKPointAnnotation();
			Anno22.Title = "Federation Okinawa Karate - Shorin ryu Shorinkan South Asia (FOKSSA)";
			Anno22.Subtitle = "Sri Lanka";
			Anno22.Coordinate = new CLLocationCoordinate2D(6.8399245, 79.9085643999999);

			MKPointAnnotation Anno23 = new MKPointAnnotation();
			Anno23.Title = "Freeman's Shorin-Ryu Karate";
			Anno23.Subtitle = "USA";
			Anno23.Coordinate = new CLLocationCoordinate2D(39.557548, -119.70646699999998);

			MKPointAnnotation Anno24 = new MKPointAnnotation();
			Anno24.Title = "Green's Martial Arts";
			Anno24.Subtitle = "USA";
			Anno24.Coordinate = new CLLocationCoordinate2D(37.0401124, -76.40703889999998);

			MKPointAnnotation Anno25 = new MKPointAnnotation();
			Anno25.Title = "Haley's Martial Arts Center";
			Anno25.Subtitle = "USA";
            Anno25.Coordinate = new CLLocationCoordinate2D(39.7539942, -121.851339);

			MKPointAnnotation Anno26 = new MKPointAnnotation();
			Anno26.Title = "Huges Karate Do";
			Anno26.Subtitle = "USA";
			Anno26.Coordinate = new CLLocationCoordinate2D(33.2934365, -111.83133559999999);

			MKPointAnnotation Anno27 = new MKPointAnnotation();
			Anno27.Title = "Impact Martial Art";
			Anno27.Subtitle = "USA";
			Anno27.Coordinate = new CLLocationCoordinate2D(43.1543339, -85.710353);

			MKPointAnnotation Anno28 = new MKPointAnnotation();
			Anno28.Title = "Jay King's Karate";
			Anno28.Subtitle = "USA";
			Anno28.Coordinate = new CLLocationCoordinate2D(37.4517876, -79.1212832);

			MKPointAnnotation Anno29 = new MKPointAnnotation();
			Anno29.Title = "Shorin-Ryu Shorinkan";
			Anno29.Subtitle = "Denmark";
			Anno29.Coordinate = new CLLocationCoordinate2D(55.617105, 12.604799700000058);

			MKPointAnnotation Anno30 = new MKPointAnnotation();
			Anno30.Title = "San Francisco Shorin Ryu Shorinka";
			Anno30.Subtitle = "USA";
			Anno30.Coordinate = new CLLocationCoordinate2D(37.7711151, -122.40663130000002);

			MKPointAnnotation Anno31 = new MKPointAnnotation();
			Anno31.Title = "Middle East Karate Academy";
			Anno31.Subtitle = "Dubai";
			Anno31.Coordinate = new CLLocationCoordinate2D(25.1491849, 55.246249499999976);

			MKPointAnnotation Anno32 = new MKPointAnnotation();
			Anno32.Title = "Madison's Karate";
			Anno32.Subtitle = "USA";
			Anno32.Coordinate = new CLLocationCoordinate2D(36.8201037, -76.12139830000001);

			MKPointAnnotation Anno33 = new MKPointAnnotation();
			Anno33.Title = "Shorinkan West";
			Anno33.Subtitle = "USA";
			Anno33.Coordinate = new CLLocationCoordinate2D(33.1702779, -117.35758759999999);

			MKPointAnnotation Anno34 = new MKPointAnnotation();
			Anno34.Title = "OBI Karate School of Virginia Beach";
			Anno34.Subtitle = "USA";
			Anno34.Coordinate = new CLLocationCoordinate2D(36.8507119, -76.17071779999998);

			MKPointAnnotation Anno35 = new MKPointAnnotation();
			Anno35.Title = "Peaceful Warrior Martial Arts";
			Anno35.Subtitle = "USA";
			Anno35.Coordinate = new CLLocationCoordinate2D(33.6143949, -111.91193520000002);

			MKPointAnnotation Anno36 = new MKPointAnnotation();
			Anno36.Title = "Ray Owles Shorin-Ryu Karate-Do & Kobudo";
			Anno36.Subtitle = "USA";
			Anno36.Coordinate = new CLLocationCoordinate2D(29.5176157, -95.28895779999999);

			MKPointAnnotation Anno37 = new MKPointAnnotation();
			Anno37.Title = "Cheeseman Martial Arts";
			Anno37.Subtitle = "USA";
			Anno37.Coordinate = new CLLocationCoordinate2D(37.0275114, -76.42921790000003);

			MKPointAnnotation Anno38 = new MKPointAnnotation();
			Anno38.Title = "Sanshin Martial Arts";
			Anno38.Subtitle = "USA";
			Anno38.Coordinate = new CLLocationCoordinate2D(43.5000387, -80.213773);

			MKPointAnnotation Anno39 = new MKPointAnnotation();
			Anno39.Title = "Scott Hayes Karate";
			Anno39.Subtitle = "USA";
			Anno39.Coordinate = new CLLocationCoordinate2D(43.5000387, -80.213773);

			MKPointAnnotation Anno40 = new MKPointAnnotation();
			Anno40.Title = "Claude Johnson Shorin-Ryu Karate";
			Anno40.Subtitle = "South Africa";
			Anno40.Coordinate = new CLLocationCoordinate2D(-33.9545256, 25.529618700000015);

			MKPointAnnotation Anno41 = new MKPointAnnotation();
			Anno41.Title = "S & K Karate Club";
			Anno41.Subtitle = "South Africa";
			Anno41.Coordinate = new CLLocationCoordinate2D(-33.96224, 25.588831400000004);

			MKPointAnnotation Anno42 = new MKPointAnnotation();
			Anno42.Title = "KwaNobuhle Mighty Eagles";
			Anno42.Subtitle = "South Africa";
			Anno42.Coordinate = new CLLocationCoordinate2D(-33.768717, 25.41411930000004);

			MKPointAnnotation Anno43 = new MKPointAnnotation();
			Anno43.Title = "Tom's Dojo";
			Anno43.Subtitle = "South Africa";
			Anno43.Coordinate = new CLLocationCoordinate2D(-31.887208, 26.880978000000027);

			MKPointAnnotation Anno44 = new MKPointAnnotation();
			Anno44.Title = "Anthea's Dojo";
			Anno44.Subtitle = "South Africa";
			Anno44.Coordinate = new CLLocationCoordinate2D(-33.965032, 25.615950999999995);

			MKPointAnnotation Anno45 = new MKPointAnnotation();
			Anno45.Title = "Tiger's Karate Club";
			Anno45.Subtitle = "South Africa";
			Anno45.Coordinate = new CLLocationCoordinate2D(-25.71152, 28.236176);

			MKPointAnnotation Anno46 = new MKPointAnnotation();
			Anno46.Title = "Kachi Knights Karate";
			Anno46.Subtitle = "South Africa";
			Anno46.Coordinate = new CLLocationCoordinate2D(-25.8604986, 28.144451600000025);

			MKPointAnnotation Anno47 = new MKPointAnnotation();
            Anno47.Title = "Academy of Disciple CC - Western Cape";
			Anno47.Subtitle = "South Africa";
			Anno47.Coordinate = new CLLocationCoordinate2D(-33.3689502, 19.311718199999973);

			MKPointAnnotation Anno48 = new MKPointAnnotation();
			Anno48.Title = "Bushi Fitness";
			Anno48.Subtitle = "USA";
			Anno48.Coordinate = new CLLocationCoordinate2D(35.45939450000001, -82.5314947);

			MKPointAnnotation Anno49 = new MKPointAnnotation();
			Anno49.Title = "Shorin Ryu Shorinkan Karate Do";
			Anno49.Subtitle = "India";
			Anno49.Coordinate = new CLLocationCoordinate2D(12.8918729, 77.59867179999992);

			MKPointAnnotation Anno50 = new MKPointAnnotation();
			Anno50.Title = "Karate Kids in America";
			Anno50.Subtitle = "USA";
			Anno50.Coordinate = new CLLocationCoordinate2D(33.2140159, -117.256422);

			MKPointAnnotation Anno51 = new MKPointAnnotation();
			Anno51.Title = "South Metro Authentic Ancient Arts";
			Anno51.Subtitle = "USA";
			Anno51.Coordinate = new CLLocationCoordinate2D(44.8712953, -93.40109949999999);

			MKPointAnnotation Anno52 = new MKPointAnnotation();
			Anno52.Title = "Shorin Ryu Shorinkan Karate-do & Kobudo";
			Anno52.Subtitle = "Chile";
			Anno52.Coordinate = new CLLocationCoordinate2D(-38.7420007, -72.60182789999999);

			MKPointAnnotation Anno53 = new MKPointAnnotation();
			Anno53.Title = "Traditional Okinawan School of Karate";
			Anno53.Subtitle = "Bermuda";
			Anno53.Coordinate = new CLLocationCoordinate2D(32.3842333, -64.6738398);

			MKPointAnnotation Anno54 = new MKPointAnnotation();
			Anno54.Title = "Traditional Shorin-Ryu Karate-Do of Raleigh";
			Anno54.Subtitle = "USA";
			Anno54.Coordinate = new CLLocationCoordinate2D(35.8921211, -78.59966729999996);

			MKPointAnnotation Anno55 = new MKPointAnnotation();
			Anno55.Title = "Welch's Okinawan Karate Shorin-Ryu Shorinkan";
			Anno55.Subtitle = "USA";
			Anno55.Coordinate = new CLLocationCoordinate2D(38.955653, -76.96131400000002);

			MKPointAnnotation Anno56 = new MKPointAnnotation();
			Anno56.Title = "Bethea's Karate Studio";
			Anno56.Subtitle = "USA";
			Anno56.Coordinate = new CLLocationCoordinate2D(40.4864673, -86.13123209999998);

			MKPointAnnotation Anno57 = new MKPointAnnotation();
			Anno57.Title = "Shorin-Ryu Karate of Williamsburg";
			Anno57.Subtitle = "USA";
			Anno57.Coordinate = new CLLocationCoordinate2D(37.342575, -76.748911);

			MKPointAnnotation Anno58 = new MKPointAnnotation();
			Anno58.Title = "Argentina Shorin-Ryu";
			Anno58.Subtitle = "";
			Anno58.Coordinate = new CLLocationCoordinate2D(-31.38401, -64.18108310000002);

			MKPointAnnotation Anno59 = new MKPointAnnotation();
			Anno59.Title = "Tigers Karate Club, Kachi Karate, Academy of Discipline";
			Anno59.Subtitle = "South Africa";
			Anno59.Coordinate = new CLLocationCoordinate2D(-33.9321045, 18.86015199999997);

			MKPointAnnotation Anno60 = new MKPointAnnotation();
			Anno60.Title = "Wellington, Boland Dragons";
			Anno60.Subtitle = "South Africa";
			Anno60.Coordinate = new CLLocationCoordinate2D(-33.886966, 19.050340);

			MKPointAnnotation Anno61 = new MKPointAnnotation();
			Anno61.Title = "Iron Butterfly Karate Shorin Ryu Shorinkan";
			Anno61.Subtitle = "Canada";
			Anno61.Coordinate = new CLLocationCoordinate2D(43.807900, -79.216092);

			MKPointAnnotation Anno62 = new MKPointAnnotation();
			Anno62.Title = "Vik Family Shorin Ryu Shorinkan";
			Anno62.Subtitle = "USA";
			Anno62.Coordinate = new CLLocationCoordinate2D(32.886680, -116.922589);

			MKPointAnnotation Anno63 = new MKPointAnnotation();
			Anno63.Title = "Shorinkan Karate of Connecticut";
			Anno63.Subtitle = "USA";
			Anno63.Coordinate = new CLLocationCoordinate2D(41.556629,-72112852);

			MKPointAnnotation Anno64 = new MKPointAnnotation();
			Anno64.Title = "Victorian Shorinkan Karate";
			Anno64.Subtitle = "Canada";
			Anno64.Coordinate = new CLLocationCoordinate2D(48.493124, -123.389230);

			MKPointAnnotation Anno65 = new MKPointAnnotation();
			Anno65.Title = "Shorinkan Dojo and Fitness - Murrieta";
			Anno65.Subtitle = "";
			Anno65.Coordinate = new CLLocationCoordinate2D(33.561192,-117.136712);

			MKPointAnnotation Anno66 = new MKPointAnnotation();
			Anno66.Title = "Shorin Ryu Shorinkan Wierda Park Karate Club";
			Anno66.Subtitle = "South Africa";
			Anno66.Coordinate = new CLLocationCoordinate2D(-25.855618, 28.151425);

			MKPointAnnotation Anno67 = new MKPointAnnotation();
			Anno67.Title = "Shorinkan Dojo, LLC";
			Anno67.Subtitle = "";
			Anno67.Coordinate = new CLLocationCoordinate2D(26.520523, -81.870000);

			MKPointAnnotation Anno68 = new MKPointAnnotation();
			Anno68.Title = "Eastlea Shorin-ryu Shorinkan";
			Anno68.Subtitle = "Zimbabwe";
			Anno68.Coordinate = new CLLocationCoordinate2D(-17.822364,31.073732);

			MKPointAnnotation Anno69 = new MKPointAnnotation();
			Anno69.Title = "Franz Karate Budokan Dojo";
			Anno69.Subtitle = "USA";
			Anno69.Coordinate = new CLLocationCoordinate2D(41.475003,-84.550617);

			MKPointAnnotation Anno70 = new MKPointAnnotation();
			Anno70.Title = "Shorin Ryu Karate Puerto Vallarta";
			Anno70.Subtitle = "Mexico";
			Anno70.Coordinate = new CLLocationCoordinate2D(20.653407, -105.225332);

			//MKPointAnnotation Anno71 = new MKPointAnnotation();
			//Anno71.Title = "";
			//Anno71.Subtitle = "";
			//Anno71.Coordinate = new CLLocationCoordinate2D(,);

			//MKPointAnnotation Anno72 = new MKPointAnnotation();
			//Anno72.Title = "";
			//Anno72.Subtitle = "";
			//Anno72.Coordinate = new CLLocationCoordinate2D(,);

			//MKPointAnnotation Anno73 = new MKPointAnnotation();
			//Anno73.Title = "";
			//Anno73.Subtitle = "";
			//Anno73.Coordinate = new CLLocationCoordinate2D(,);

			//MKPointAnnotation Anno74 = new MKPointAnnotation();
			//Anno74.Title = "";
			//Anno74.Subtitle = "";
			//Anno74.Coordinate = new CLLocationCoordinate2D(,);

			//MKPointAnnotation Anno75 = new MKPointAnnotation();
			//Anno75.Title = "";
			//Anno75.Subtitle = "";
			//Anno75.Coordinate = new CLLocationCoordinate2D(,);

			//MKPointAnnotation Anno76 = new MKPointAnnotation();
			//Anno76.Title = "";
			//Anno76.Subtitle = "";
			//Anno76.Coordinate = new CLLocationCoordinate2D(,);

			//MKPointAnnotation Anno77 = new MKPointAnnotation();
			//Anno77.Title = "";
			//Anno77.Subtitle = "";
			//Anno77.Coordinate = new CLLocationCoordinate2D(,);

			//MKPointAnnotation Anno78 = new MKPointAnnotation();
			//Anno78.Title = "";
			//Anno78.Subtitle = "";
			//Anno78.Coordinate = new CLLocationCoordinate2D(,);

			//MKPointAnnotation Anno79 = new MKPointAnnotation();
			//Anno79.Title = "";
			//Anno79.Subtitle = "";
			//Anno79.Coordinate = new CLLocationCoordinate2D(,);

			//MKPointAnnotation Anno80 = new MKPointAnnotation();
			//Anno80.Title = "";
			//Anno80.Subtitle = "";
			//Anno80.Coordinate = new CLLocationCoordinate2D(,);

			//MKPointAnnotation Anno81 = new MKPointAnnotation();
			//Anno81.Title = "";
			//Anno81.Subtitle = "";
			//Anno81.Coordinate = new CLLocationCoordinate2D(,);


			allMapView.AddAnnotation(Anno1);
            allMapView.AddAnnotation(Anno2);
			allMapView.AddAnnotation(Anno3);
			allMapView.AddAnnotation(Anno4);
			allMapView.AddAnnotation(Anno5);
			allMapView.AddAnnotation(Anno6);
			allMapView.AddAnnotation(Anno7);
			allMapView.AddAnnotation(Anno8);
			allMapView.AddAnnotation(Anno9);
			allMapView.AddAnnotation(Anno10);
			allMapView.AddAnnotation(Anno11);
			allMapView.AddAnnotation(Anno12);
			allMapView.AddAnnotation(Anno13);
			allMapView.AddAnnotation(Anno14);
			allMapView.AddAnnotation(Anno15);
			allMapView.AddAnnotation(Anno16);
			allMapView.AddAnnotation(Anno17);
			allMapView.AddAnnotation(Anno18);
			allMapView.AddAnnotation(Anno19);
			allMapView.AddAnnotation(Anno20);

			allMapView.AddAnnotation(Anno21);
			allMapView.AddAnnotation(Anno22);
			allMapView.AddAnnotation(Anno23);
			allMapView.AddAnnotation(Anno24);
			allMapView.AddAnnotation(Anno25);
			allMapView.AddAnnotation(Anno26);
			allMapView.AddAnnotation(Anno27);
			allMapView.AddAnnotation(Anno28);
			allMapView.AddAnnotation(Anno29);
			allMapView.AddAnnotation(Anno30);

			allMapView.AddAnnotation(Anno31);
			allMapView.AddAnnotation(Anno32);
			allMapView.AddAnnotation(Anno33);
			allMapView.AddAnnotation(Anno34);
			allMapView.AddAnnotation(Anno35);
			allMapView.AddAnnotation(Anno36);
			allMapView.AddAnnotation(Anno37);
			allMapView.AddAnnotation(Anno38);
			allMapView.AddAnnotation(Anno39);

			allMapView.AddAnnotation(Anno40);
			allMapView.AddAnnotation(Anno41);
			allMapView.AddAnnotation(Anno42);
			allMapView.AddAnnotation(Anno43);
			allMapView.AddAnnotation(Anno44);
			allMapView.AddAnnotation(Anno45);
			allMapView.AddAnnotation(Anno46);
			allMapView.AddAnnotation(Anno47);
			allMapView.AddAnnotation(Anno48);
			allMapView.AddAnnotation(Anno49);

			allMapView.AddAnnotation(Anno50);
			allMapView.AddAnnotation(Anno51);
			allMapView.AddAnnotation(Anno52);
			allMapView.AddAnnotation(Anno53);
			allMapView.AddAnnotation(Anno54);
			allMapView.AddAnnotation(Anno55);
			allMapView.AddAnnotation(Anno56);
			allMapView.AddAnnotation(Anno57);
			allMapView.AddAnnotation(Anno58);
			allMapView.AddAnnotation(Anno59);

			allMapView.AddAnnotation(Anno60);
			allMapView.AddAnnotation(Anno61);
			allMapView.AddAnnotation(Anno62);
			allMapView.AddAnnotation(Anno63);
			allMapView.AddAnnotation(Anno64);
			allMapView.AddAnnotation(Anno65);
			allMapView.AddAnnotation(Anno66);
			allMapView.AddAnnotation(Anno67);
			allMapView.AddAnnotation(Anno68);
			allMapView.AddAnnotation(Anno69);

			allMapView.AddAnnotation(Anno70);
			

		}


        class BasicMapAnnotation : MKAnnotation
		{
			CLLocationCoordinate2D coord;
			string title, subtitle;

			public override CLLocationCoordinate2D Coordinate { get { return coord; } }
			public override void SetCoordinate(CLLocationCoordinate2D value)
			{
				coord = value;
			}
			public override string Title { get { return title; } }
			public override string Subtitle { get { return subtitle; } }
			public BasicMapAnnotation(CLLocationCoordinate2D coordinate, string title, string subtitle)
			{
				this.coord = coordinate;
				this.title = title;
				this.subtitle = subtitle;
			}
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

