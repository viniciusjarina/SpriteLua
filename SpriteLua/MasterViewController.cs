using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Chormatism;

namespace SpriteLua
{
	public partial class MasterViewController : JLTextViewController
	{
		UIBarButtonItem doneButton;
		UIBarButtonItem dismissButton;

		public MasterViewController (IntPtr handle) : base (handle)
		{
			Title = NSBundle.MainBundle.LocalizedString ("Master", "Master");
			
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				PreferredContentSize = new SizeF (320f, 600f);
			}

		
			// Custom initialization
		}

		public DetailViewController DetailViewController {
			get;
			set;
		}



		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			doneButton = new UIBarButtonItem (UIBarButtonSystemItem.Done, OnDone);
			dismissButton = new UIBarButtonItem (UIBarButtonSystemItem.Done, OnDismissKeyBoard);

			NavigationItem.LeftBarButtonItem = doneButton;

			var playButton = new UIBarButtonItem (UIBarButtonSystemItem.Play, OnRun);
			NavigationItem.RightBarButtonItem = playButton;
		}

		void OnDismissKeyBoard (object sender, EventArgs args)
		{
			TextView.ResignFirstResponder ();
		}

		void OnRun (object sender, EventArgs args)
		{
			string script = TextView.Text;
			DetailViewController.RunScript (script);
		}

		void OnDone (object sender, EventArgs args)
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) {
				PerformSegue ("showDetail", this);
			}

			if (DetailViewController != null)
				DetailViewController.DismissMaster ();

		}

		public void Hide (bool hide)
		{
			NavigationController.View.Hidden = hide;
			View.Hidden = hide;
		}

		public override void DidRotate (UIInterfaceOrientation fromInterfaceOrientation)
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				if (UIInterfaceOrientation.Portrait.Equals (fromInterfaceOrientation) ||
				    UIInterfaceOrientation.PortraitUpsideDown.Equals (fromInterfaceOrientation)) {
					NavigationItem.LeftBarButtonItem = dismissButton;
				} else {
					NavigationItem.LeftBarButtonItem = doneButton;
				}

			}
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "showDetail") {

				var x = ((DetailViewController)segue.DestinationViewController);
			}
		}
	}
}

