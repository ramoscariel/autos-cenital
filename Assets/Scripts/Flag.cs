using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axis
{
    X,Z
}

public class Flag : MonoBehaviour
{
    public Axis axis;
    public float offset;

    public Vector3 GetPosition()
    {
        float offsetAxis = Random.Range(-offset, offset);
        if (axis == Axis.X)
        {
            return new Vector3(offsetAxis + transform.position.x, transform.position.y, transform.position.z);
        }
        else {
            return new Vector3(transform.position.x, transform.position.y, transform.position.z + offsetAxis);
        }
    }
}
