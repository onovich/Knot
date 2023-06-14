using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using MortiseFrame.Knot.Shape2D;

namespace MortiseFrame.Knot.Test {

    public class Test_Intersect2D {

        [Test]
        public void TestIsIntersectAABB_AABB() {
            // Case 1: Two AABBs overlap
            AABB a1 = new AABB(new Vector2(0, 0), new Vector2(1, 1));
            AABB b1 = new AABB(new Vector2(0.5f, 0.5f), new Vector2(1.5f, 1.5f));
            Assert.IsTrue(Intersect2DUtil.IsIntersectAABB_AABB(a1, b1, 0));

            // Case 2: Two AABBs do not overlap
            AABB a2 = new AABB(new Vector2(0, 0), new Vector2(1, 1));
            AABB b2 = new AABB(new Vector2(2, 2), new Vector2(3, 3));
            Assert.IsFalse(Intersect2DUtil.IsIntersectAABB_AABB(a2, b2, 0));
        }

        [Test]
        public void TestIsIntersectAABB_Circle() {
            // Case 1: Circle is inside AABB
            AABB aabb1 = new AABB(new Vector2(0, 0), new Vector2(3, 3));
            Circle circle1 = new Circle(new Vector2(1.5f, 1.5f), 1);
            Assert.IsTrue(Intersect2DUtil.IsIntersectAABB_Circle(aabb1, circle1, 0));

            // Case 2: Circle is outside AABB
            AABB aabb2 = new AABB(new Vector2(0, 0), new Vector2(1, 1));
            Circle circle2 = new Circle(new Vector2(3, 3), 1);
            Assert.IsFalse(Intersect2DUtil.IsIntersectAABB_Circle(aabb2, circle2, 0));
        }

        [Test]
        public void TestIsIntersectAABB_OBB() {
            // Case 1: OBB is inside AABB
            AABB aabb1 = new AABB(new Vector2(0, 0), new Vector2(3, 3));
            OBB obb1 = new OBB(new Vector2(1.5f, 1.5f), new Vector2(1, 1), 0);
            Assert.IsTrue(Intersect2DUtil.IsIntersectAABB_OBB(aabb1, obb1, 0));

            // Case 2: OBB is outside AABB
            AABB aabb2 = new AABB(new Vector2(0, 0), new Vector2(1, 1));
            OBB obb2 = new OBB(new Vector2(3, 3), new Vector2(1, 1), 0);
            Assert.IsFalse(Intersect2DUtil.IsIntersectAABB_OBB(aabb2, obb2, 0));
        }

        [Test]
        public void TestIsIntersectAABB_AABB_Epsilon() {
            // Case: Two AABBs are just touching each other
            AABB a = new AABB(new Vector2(0, 0), new Vector2(1, 1));
            AABB b = new AABB(new Vector2(1, 1), new Vector2(2, 2));
            Assert.IsFalse(Intersect2DUtil.IsIntersectAABB_AABB(a, b, float.Epsilon));
            Assert.IsTrue(Intersect2DUtil.IsIntersectAABB_AABB(a, b, -float.Epsilon));
        }

        [Test]
        public void TestIsIntersectAABB_Circle_Epsilon() {
            // Case: Circle is just touching the AABB
            AABB aabb = new AABB(new Vector2(0, 0), new Vector2(2, 2));
            Circle circle = new Circle(new Vector2(3, 1), 1);
            Assert.IsFalse(Intersect2DUtil.IsIntersectAABB_Circle(aabb, circle, 0.1f));
            Assert.IsTrue(Intersect2DUtil.IsIntersectAABB_Circle(aabb, circle, -0.1f));
        }

        [Test]
        public void TestIsIntersectAABB_OBB_Epsilon() {
            // Case: OBB is just touching the AABB
            AABB aabb = new AABB(new Vector2(0, 0), new Vector2(1, 1));
            OBB obb = new OBB(new Vector2(1.5f, 0.5f), new Vector2(1, 1), 0);
            Assert.IsFalse(Intersect2DUtil.IsIntersectAABB_OBB(aabb, obb, 0.1f));
            Assert.IsTrue(Intersect2DUtil.IsIntersectAABB_OBB(aabb, obb, -0.1f));
        }

        [Test]
        public void TestIsIntersectAABB_OBB_Epsilon_Angle() {
            // Case: OBB is just touching the AABB
            AABB aabb = new AABB(new Vector2(0, 0), new Vector2(1, 1));
            OBB obb = new OBB(new Vector2(1.59f, 1.59f), new Vector2(1, 1), 0);
            Assert.IsFalse(Intersect2DUtil.IsIntersectAABB_OBB(aabb, obb, 0.1f));
            Assert.IsTrue(Intersect2DUtil.IsIntersectAABB_OBB(aabb, obb, -0.1f));
        }

    }

}
