using Foundation;
using System;
using UIKit;
using System.Threading.Tasks;
using PortableShareLibrary;
using System.Net.Http;
using Newtonsoft.Json;

namespace ComplianceApp.iOS
{
    public partial class FacebookController : UIViewController
    {
        public FacebookController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            RefreshDataAsync();

			string[] tableItems = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
            MyTable.Source = new TableSource(tableItems);
		}


		//Your snippet looked all OK to me and I just gave it a try and it worked like charm for me.I got JSON string in content variable and I could deserialize it also.Here am sharing the snippet I used.

        public static async Task RefreshDataAsync()
		{
			var uri = new Uri("https://storage.googleapis.com/shorinryu-shorinkan-app/test.json");
			
			HttpClient myClient = new HttpClient();

			var response = await myClient.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var Items = JsonConvert.DeserializeObject<System.Collections.Generic.List<MapItem>>(content);
				Console.WriteLine("" );
			}
		}




		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
    }
}