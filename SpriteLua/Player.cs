using System;
using MonoTouch.SpriteKit;
using MonoTouch.UIKit;
using System.Drawing;

namespace SpriteLua
{
	public class Player
	{
		public static MyScene MainScene;



		SKSpriteNode sprite;

		public Player (string type)
		{
			sprite = new SKSpriteNode (type);
			sprite.Position = UIScreen.MainScreen.Bounds.Center ();
			MainScene.AddChild (sprite);
		}

		public void Rotate (float angle, double seconds = 1.0, uint count = 1)
		{
			var action = SKAction.RotateByAngle (angle, seconds);
			var run = SKAction.RepeatAction (action, count);
			sprite.RunAction (run);
		}

		public void MoveTo (int x, int y, double seconds = 1.0)
		{
			var move = SKAction.MoveTo (new PointF (x, y), seconds);
			sprite.RunAction (move);
		}

		public void FadeAlphaTo (float alpha, double seconds = 1.0)
		{
			var fade = SKAction.FadeAlphaTo (alpha, seconds);
			sprite.RunAction (fade);
		}

		public void ScaleTo (float scale, double seconds = 1.0)
		{
			var action = SKAction.ScaleTo (scale, seconds);
			sprite.RunAction (action);
		}
	
	}
}

