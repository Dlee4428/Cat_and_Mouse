using UnityEngine;

public static class VectorExtensions
{
    public static Vector2 XY(this Vector3 v)
    { return new Vector2(v.x, v.y); }

    public static Vector3 XYZ(this Vector3 v)
    { return new Vector3(v.x, v.y, v.z); }
}
