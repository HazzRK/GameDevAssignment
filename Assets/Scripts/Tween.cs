using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween
{
    public Transform Target { get; private set; }
    public Vector3 StartPos { get; private set; }
    public Vector3 EndPos { get; private set; }
    public float StartTime { get; private set; }
    public float Duration { get; private set; }

    public Tween(Transform t, Vector3 sp, Vector3 ep, float st, float d)
    {
        Target = t;
        StartPos = sp;
        EndPos = ep;
        StartTime = st;
        Duration = d;
    }

}
