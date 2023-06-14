using MortiseFrame.Knot.Shape2D;
using UnityEngine;

namespace MortiseFrame.Knot {

    public static class Intersect2DUtil {

        public static bool IsIntersectAABB_AABB(AABB a, AABB b, float epsilon) {

            var res = ((b.Max.y - a.Min.y > epsilon)
                && (a.Max.y - b.Min.y > epsilon)
                && (b.Max.x - a.Min.x > epsilon)
                && (a.Max.x - b.Min.x > epsilon));

            return res;

        }

        public static bool IsIntersectAABB_Circle(AABB aabb, Circle circle, float epsilon) {

            var i = aabb.GetCenter() - circle.Center;
            var v = Vector2.Max(i, -i);
            var diff = Vector2.Max(v - aabb.GetSize() * 0.5f, Vector2.zero);
            var res = circle.Radius * circle.Radius - diff.sqrMagnitude > epsilon;

            return res;

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

            var res = b.Max - a.Min > epsilon && a.Max - b.Min > epsilon;
            return res;

        }

    }

}
