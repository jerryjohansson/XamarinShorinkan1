// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ComplianceApp.iOS
{
    [Register ("MapController")]
    partial class MapController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView allMapView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (allMapView != null) {
                allMapView.Dispose ();
                allMapView = null;
            }
        }
    }
}