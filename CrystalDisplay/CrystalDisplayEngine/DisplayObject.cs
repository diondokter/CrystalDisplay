using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;


namespace CrystalDisplay.Engine
{
    public abstract class DisplayObject
    {
		public DisplayObject Parent;

		public Vector3 Position
		{
			get
			{
				return (Parent?.Position ?? Vector3.Zero) + Vector3.Transform(LocalPosition * (Parent?.Scale ?? Vector3.One), LocalRotation);
			}
			set
			{
				LocalPosition = value - (Parent?.Position ?? Vector3.Zero);
			}
		}

		public Quaternion Rotation
		{
			get
			{
				return (Parent?.Rotation ?? Quaternion.Identity) * LocalRotation;
			}
			set
			{
				LocalRotation = value / (Parent?.Rotation ?? Quaternion.Identity);
			}
		}

		public Vector3 Scale
		{
			get
			{
				return (Parent?.Scale ?? Vector3.One) * LocalScale;
			}
			set
			{
				LocalScale = value / (Parent?.Scale ?? Vector3.One);
			}
		}

		public Vector2 Scale2D
		{
			get
			{
				Vector3 Scale = this.Scale;
				return new Vector2(Scale.X, Scale.Y);
			}
		}

		public Vector3 LocalPosition { get; set; }
		public Quaternion LocalRotation { get; set; }
		public Vector3 LocalScale { get; set; } = Vector3.One;

		/// <summary>
		/// Checks if the the object is in the ray
		/// </summary>
		/// <param name="RayPosition">The origin of the ray</param>
		public abstract (bool Hit, float DistanceSquared, Vector2 UV) GetHit(Vector2 RayPosition);

		/// <summary>
		/// Gets the color of the object using the UV coord
		/// </summary>
		/// <param name="UV">The UV position</param>
		/// <returns>The color at the specified UV</returns>
		protected abstract Color GetColor(Vector2 UV);
    }
}
