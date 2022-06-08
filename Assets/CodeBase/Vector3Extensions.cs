using UnityEngine;

namespace Assets.CodeBase
{
    public static class Vector3Extensions
    {
        public static Vector3 ClampAllComponents(this Vector3 vector, float min, float max)
        {
            Vector3 newVector = vector;

            newVector.x = Mathf.Clamp(newVector.x, min, max);
            newVector.y = Mathf.Clamp(newVector.y, min, max);
            newVector.z = Mathf.Clamp(newVector.z, min, max);

            return newVector;
        }
    }
}