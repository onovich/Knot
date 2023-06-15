using UnityEngine;

namespace MortiseFrame.Knot.Shape2D {

    public class AABB {

        Vector2 min;
        public Vector2 Min => min;

        Vector2 max;
        public Vector2 Max => max;

        public AABB(Vector2 min, Vector2 max) {
            this.min = min;
            this.max = max;
        }

        public void FromCenter(Vector2 center, Vector2 size) {
            min = center - size * 0.5f;
            max = center + size * 0.5f;
        }

        public Vector2 GetCenter() {
            return (min + max) * 0.5f;
        }

        public Vector2 GetSize() {
            return max - min;
        }

        public bool Contains(Vector2 point) {
            return point.x >= min.x && point.x <= max.x && point.y >= min.y && point.y <= max.y;
        }

        public (float Min, float Max) ProjectOntoAxis(Vector2 axis) {
            Vector2[] vertices = new Vector2[4];
            vertices[0] = this.Min;
            vertices[1] = new Vector2(this.Min.x, this.Max.y);
            vertices[2] = this.Max;
            vertices[3] = new Vector2(this.Max.x, this.Min.y);

            float min = Vector2.Dot(vertices[0], axis);
            float max = min;

            for (int i = 1; i < vertices.Length; i++) {
                float dotProduct = Vector2.Dot(vertices[i], axis);
                if (dotProduct < min) {
                    min = dotProduct;
                } else if (dotProduct > max) {
                    max = dotProduct;
                }
            }

            return (min, max);
        }

        public Vector2[] GetAxis() {
            Vector2[] axes = new Vector2[2];
            axes[0] = new Vector2(1, 0);
            axes[1] = new Vector2(0, 1);
            return axes;
        }

    }

}