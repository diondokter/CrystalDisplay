using CrystalDisplay.Engine;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CrystalDisplay.Input
{
	public class ShapeObject : DisplayObject2D
	{
		private Vector2 _Size = Vector2.One;
		public override Vector2 Size
		{
			get
			{
				return _Size;
			}

			set
			{
				_Size = value;
			}
		}
		public Shape ObjectShape;
		public Color BackgroundColor;


		protected override Color GetColor(Vector2 UV)
		{
			switch (ObjectShape)
			{
				case Shape.Triangle:

					if (UV.X > (UV.Y / 2 - 0.5f) && UV.X < (UV.Y / 2 + 0.5f))
					{
						return BackgroundColor;
					}
					break;

				case Shape.Square:

					return BackgroundColor;

				case Shape.Circle:

					if (UV.LengthSquared() < 1)
					{
						return BackgroundColor;
					}
					break;
			}

			return new Color();
		}

		public enum Shape
		{
			Triangle, Square, Circle
		}
	}
}
