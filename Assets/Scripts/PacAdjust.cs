using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacAdjust : MonoBehaviour
{
    
    [SerializeField]
    private GameObject item;

    private Tweener tweener;
   

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        item.transform.position = new Vector3(-36.0f, 41f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (item.transform.position == new Vector3(-36.0f, 41f, 0.0f))
        {
            Quaternion target = Quaternion.Euler(0, 0, 0);
            item.transform.rotation = Quaternion.Slerp(item.transform.rotation, target, 1);
            item.transform.localScale = new Vector3(1, 1, 1);
            float dist = Vector3.Distance(item.transform.position, new Vector3(-20.0f, 41f, 0.0f));
            tweener.AddTween(item.transform, item.transform.position, new Vector3(-20.0f, 41f, 0.0f), dist / 8f);
        } else if (item.transform.position == new Vector3(-20.0f, 41f, 0.0f))
        {
            Quaternion target = Quaternion.Euler(0, 0, -90);
            item.transform.rotation = Quaternion.Slerp(item.transform.rotation, target, 1);
            float dist = Vector3.Distance(item.transform.position, new Vector3(-20.0f, 28f, 0.0f));
            tweener.AddTween(item.transform, item.transform.position, new Vector3(-20.0f, 28f, 0.0f), dist / 8f);
        } else if (item.transform.position == new Vector3(-20.0f, 28f, 0.0f))
        {
            Quaternion target = Quaternion.Euler(0, 0, -180);
            item.transform.rotation = Quaternion.Slerp(item.transform.rotation, target, 1);
            item.transform.localScale = new Vector3(1, -1, 1);
            float dist = Vector3.Distance(item.transform.position, new Vector3(-36.0f, 28f, 0.0f));
            tweener.AddTween(item.transform, item.transform.position, new Vector3(-36.0f, 28f, 0.0f), dist / 8f);
        } else if (item.transform.position == new Vector3(-36.0f, 28f, 0.0f))
        {
            Quaternion target = Quaternion.Euler(0, 0, 90);
            item.transform.rotation = Quaternion.Slerp(item.transform.rotation, target, 1);
            float dist = Vector3.Distance(item.transform.position, new Vector3(-36.0f, 41f, 0.0f));
            tweener.AddTween(item.transform, item.transform.position, new Vector3(-36.0f, 41f, 0.0f), dist / 8f);
        }
    }
}
