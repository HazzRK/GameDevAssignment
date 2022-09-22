using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private Tween activeTween;
    //private List<Tween> activeTweens = new List<Tween>();


    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activeTween != null)
        {
            
            float t = (Time.time - activeTween.StartTime) / activeTween.Duration;
            float t2 = t * t * t;

            if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) > 0.1f)
            {
                activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, t);
            }
            else if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) <= 0.1f)
            {
                activeTween.Target.position = activeTween.EndPos;
            }
        }
    }
}
