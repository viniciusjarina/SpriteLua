using System;
using System.Drawing;

namespace SpriteLua
{
	public static class RectangleExtension
	{
		public static PointF Center(this RectangleF rectangle)
		{
			return new PointF(rectangle.X + rectangle.Width / 2,
				rectangle.Y + rectangle.Height / 2);
		}
	}
}

