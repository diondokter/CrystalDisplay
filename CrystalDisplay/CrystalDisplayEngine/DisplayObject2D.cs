using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CrystalDisplay.Engine
{
    public abstract class DisplayObject2D : DisplayObject
    {
		public Vector3 Normal => Vector3.Transform(Vector3.UnitZ, Rotation);
		public Vector2 Extention => Size / 2;
		public abstract Vector2 Size { get; set; }

		public override (bool Hit, float DistanceSquared, Vector2 UV) GetHit(Vector2 RayPosition)
		{
			// Get the position on which the plane is hit
			(bool HasHit, Vector3 Position) IntersectionResult = LinePlaneIntersection(new Vector3(RayPosition, 0), -Vector3.UnitZ, Normal, Position);

			// Rotate the position back to local space
			Vector3 LocalIntersectionPosition = Vector3.Transform(IntersectionResult.Position / Scale, -Rotation) - Position;
			Vector2 LocalIntersectionPosition2D = new Vector2(LocalIntersectionPosition.X, LocalIntersectionPosition.Y);

			// To UV coords
			Vector2 UV = ((LocalIntersectionPosition2D / Extention) + Vector2.One) / 2;

			return (UV.X < 0 || UV.X > 1 || UV.Y < 0 || UV.X > 1, Vector3.DistanceSquared(IntersectionResult.Position, new Vector3(RayPosition, 0)), UV);
		}

		//Get the intersection between a line and a plane. 
		//If the line and plane are not parallel, the function outputs true, otherwise false.
		private static (bool HasHit, Vector3 Position) LinePlaneIntersection(Vector3 linePoint, Vector3 lineVec, Vector3 planeNormal, Vector3 planePoint)
		{
			//calculate the distance between the linePoint and the line-plane intersection point
			float dotNumerator = Vector3.Dot((planePoint - linePoint), planeNormal);
			float dotDenominator = Vector3.Dot(lineVec, planeNormal);

			//line and plane are not parallel
			if (dotDenominator != 0.0f)
			{
				//create a vector from the linePoint to the intersection point
				//get the coordinates of the line-plane intersection point
				return (true, linePoint + Vector3.Normalize(lineVec) * dotNumerator / dotDenominator);
			}		
			else //output not valid
			{
				return (false, Vector3.Zero);
			}
		}
	}
}
