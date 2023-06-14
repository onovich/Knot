using UnityEngine;

namespace MortiseFrame.Knot.Shape2D {

    public class OBB {

        Vector2 axisX;
        public Vector2 AxisX => axisX;

        Vector2 axisY;
        public Vector2 AxisY => axisY;

        Vector2 center;
        public Vector2 Center => center;

        Vector2 size;
        public Vector2 Size => size;

        Vector2[] vertices;
        public Vector2[] Vertices => vertices;

        float radAngle;
        public float RadAngle => radAngle;

        public OBB(Vector2 center, Vector2 size, float radAngle) {

            this.center = center;
            this.size = size;
            this.radAngle = radAngle;
            this.axisX = new Vector2(Mathf.Cos(radAngle), Mathf.Sin(radAngle));
            this.axisY = new Vector2(-axisX.y, axisX.x);
            var vertices = new Vector2[4];
            vertices[0] = center + axisX * size.x * 0.5f + axisY * size.y * 0.5f;
            vertices[1] = center - axisX * size.x * 0.5f + axisY * size.y * 0.5f;
            vertices[2] = center - axisX * size.x * 0.5f - axisY * size.y * 0.5f;
            vertices[3] = center + axisX * size.x * 0.5f - axisY * size.y * 0.5f;
            this.vertices = vertices;

        }

        public bool Contains(Vector2 point) {
            var localPoint = point - center;
            var localX = Vector2.Dot(localPoint, axisX);
            var localY = Vector2.Dot(localPoint, axisY);
            return Mathf.Abs(localX) <= size.x * 0.5f && Mathf.Abs(localY) <= size.y * 0.5f;
        }

        public Vector2[] GetAxes() {
            Vector2[] axes = new Vector2[4];
            axes[0] = this.axisX;
            axes[1] = this.axisY;
            axes[2] = new Vector2(1, 0);
            axes[3] = new Vector2(0, 1);
            return axes;
        }

        public (float Min, float Max) ProjectOntoAxis(Vector2 axis) {
            float dotProduct = Vector2.Dot(this.Vertices[0], axis);
            float min = dotProduct;
            float max = dotProduct;

            for (int i = 1; i < this.Vertices.Length; i++) {
                dotProduct = Vector2.Dot(this.Vertices[i], axis);
                if (dotProduct < min) {
                    min = dotProduct;
                } else if (dotProduct > max) {
                    max = dotProduct;
                }
            }

            return (min, max);
        }

    }

}