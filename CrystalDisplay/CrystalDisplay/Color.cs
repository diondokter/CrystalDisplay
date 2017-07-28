using System;
using System.Collections.Generic;
using System.Text;

namespace CrystalDisplay
{
    public struct Color
    {
		private const int RedOffset = 24;
		private const int GreenOffset = 16;
		private const int BlueOffset = 8;
		private const int AlphaOffset = 0;

		public int Value { get; private set; }

		public byte R
		{
			get
			{
				return (byte)((Value >> RedOffset) & 0xff);
			}
		}
		public float Rf
		{
			get
			{
				return (float)((Value >> RedOffset) & 0xff) / byte.MaxValue;
			}
		}

		public byte G
		{
			get
			{
				return (byte)((Value >> GreenOffset) & 0xff);
			}
		}
		public float Gf
		{
			get
			{
				return (float)((Value >> GreenOffset) & 0xff) / byte.MaxValue;
			}
		}

		public byte B
		{
			get
			{
				return (byte)((Value >> BlueOffset) & 0xff);
			}
		}
		public float Bf
		{
			get
			{
				return (float)((Value >> BlueOffset) & 0xff) / byte.MaxValue;
			}
		}

		public byte A
		{
			get
			{
				return (byte)((Value >> AlphaOffset) & 0xff);
			}
		}
		public float Af
		{
			get
			{
				return (float)((Value >> AlphaOffset) & 0xff) / byte.MaxValue;
			}
		}


		public Color(int value)
		{
			this.Value = value;
		}

		public Color(byte r, byte g, byte b) : this(r, g, b, byte.MaxValue) { }
		public Color(byte r, byte g, byte b, byte a) : this(r << RedOffset | g << GreenOffset | b << BlueOffset | a << AlphaOffset) { }
		public Color(float r, float g, float b) : this(r, g, b, 1f) { }
		public Color(float r, float g, float b, float a) : this((byte)(r * byte.MaxValue), (byte)(g * byte.MaxValue), (byte)(b * byte.MaxValue), (byte)(a * byte.MaxValue)) { }

		public Color SetR(byte r)
		{
			return new Color(r, G, B, A);
		}
		public Color SetR(float r)
		{
			return new Color(r, G, B, A);
		}

		public Color SetG(byte g)
		{
			return new Color(R, g, B, A);
		}
		public Color SetG(float g)
		{
			return new Color(R, g, B, A);
		}

		public Color SetB(byte b)
		{
			return new Color(R, G, b, A);
		}
		public Color SetB(float b)
		{
			return new Color(R, G, b, A);
		}

		public Color SetA(byte a)
		{
			return new Color(R, G, B, a);
		}
		public Color SetA(float a)
		{
			return new Color(R, G, B, a);
		}
	}
}
