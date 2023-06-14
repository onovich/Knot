using MortiseFrame.Knot.Shape2D;
using UnityEngine;

namespace MortiseFrame.Knot {

    public static class Intersect2DUtil {

        public static bool IsIntersectAABB_AABB(AABB a, AABB b, float epsilon) {

            if (a.Min.x > b.Max.x + epsilon || a.Max.x < b.Min.x - epsilon) {
                return false;
            }

            if (a.Min.y > b.Max.y + epsilon || a.Max.y < b.Min.y - epsilon) {
                return false;
            }

            return true;

        }

        public static bool IsIntersectAABB_Circle(AABB aabb, Circle circle, float epsilon) {

            Vector2 closestPoint = new Vector2(
                Mathf.Clamp(circle.Center.x, aabb.Min.x, aabb.Max.x),
                Mathf.Clamp(circle.Center.y, aabb.Min.y, aabb.Max.y)
            );

            float distanceSquared = (circle.Center - closestPoint).sqrMagnitude;
            float radiusSquared = (circle.Radius + epsilon) * (circle.Radius + epsilon);

            return distanceSquared <= radiusSquared;

        }

        public static bool IsIntersectAABB_OBB(AABB aabb, OBB obb, float epsilon) {

            Vector2[] obbAxes = obb.GetAxes();

            for (int i = 0; i < obbAxes.Length; i++) {
                (float Min, float Max) projectionA = aabb.ProjectOntoAxis(obbAxes[i]);
                (float Min, float Max) projectionB = obb.ProjectOntoAxis(obbAxes[i]);

                if (!ProjectionsOverlap(projectionA, projectionB, epsilon)) {
                    return false;
                }
            }

            return true;

        }

        public static bool ProjectionsOverlap((float Min, float Max) a, (float Min, float Max) b, float epsilon) {

            if (a.Max < b.Min - epsilon || a.Min > b.Max + epsilon) {
                return false;
            }

            return true;

        }

    }

}
