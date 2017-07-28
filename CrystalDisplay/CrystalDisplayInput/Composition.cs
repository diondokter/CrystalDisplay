using CrystalDisplay.Engine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace CrystalDisplay.Input
{
	public class Composition
	{
		public Color BackgroundColor;
		public List<DisplayObject> Objects { get; } = new List<DisplayObject>();
		public Vector2 CameraPosition;
	}
}
