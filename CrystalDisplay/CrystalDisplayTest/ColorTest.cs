using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrystalDisplay.Engine;

namespace CrystalDisplayEngineTest
{
	[TestClass]
	public class ColorTest
	{
		[TestMethod]
		public void TestValues()
		{
			Color c = new Color(0);

			Assert.IsTrue(c.Value == 0);
			Assert.IsTrue(c.R == 0);
			Assert.IsTrue(c.G == 0);
			Assert.IsTrue(c.B == 0);
			Assert.IsTrue(c.A == 0);
			Assert.IsTrue(c.Rf == 0);
			Assert.IsTrue(c.Gf == 0);
			Assert.IsTrue(c.Bf == 0);
			Assert.IsTrue(c.Af == 0);

			c = new Color(255, 254, 253, 252);

			Assert.IsTrue(c.R == 255);
			Assert.IsTrue(c.G == 254);
			Assert.IsTrue(c.B == 253);
			Assert.IsTrue(c.A == 252);

			c = new Color(0.5f, 0.5f, 0.5f, 0.5f);

			Assert.IsTrue(c.R == 127);
			Assert.IsTrue(c.G == 127);
			Assert.IsTrue(c.B == 127);
			Assert.IsTrue(c.A == 127);
			Assert.IsTrue(c.Rf > 0.49f && c.Rf < 0.51f);
			Assert.IsTrue(c.Gf > 0.49f && c.Gf < 0.51f);
			Assert.IsTrue(c.Bf > 0.49f && c.Bf < 0.51f);
			Assert.IsTrue(c.Af > 0.49f && c.Af < 0.51f);

			c = new Color(127, 127, 127);

			Assert.IsTrue(c.A == 255);

			c = new Color(0.5f, 0.5f, 0.5f);

			Assert.IsTrue(c.A == 255);
		}
	}
}
