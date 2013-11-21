using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.SpriteKit;
using MonoTouch.UIKit;
using NLua;

namespace SpriteLua
{
	public class MyScene : SKScene
	{
		Lua lua = new Lua ();

		public MyScene (SizeF size) : base (size)
		{
			lua.LoadCLRPackage ();
			lua.DoString ("import ('SpriteLua') import ('System')");

			Player.MainScene = this;
			// Setup your scene here
			BackgroundColor = new UIColor (0.15f, 0.15f, 0.3f, 1.0f);

			var myLabel = new SKLabelNode ("Chalkduster") {
				Text = "NLua!",
				FontSize = 30,
			};

			myLabel.Position = new PointF (Frame.X + Frame.Width / 2, Frame.Y + Frame.Height / 2);

			AddChild (myLabel);
		}

		public void OnRunScript (string script)
		{
			try {
				lua.DoString (script);
			}
			catch (Exception e) {
				UIAlertView alert = new UIAlertView ();
				alert.Title = "Lua Error";
				alert.Message = "Error running Lua code: " + e.ToString ();
				alert.AddButton ("OK");
				alert.Show ();
			}
		}


		public override void Update (double currentTime)
		{
			// Run before each frame is rendered
			base.Update (currentTime);
		}
	}
}
