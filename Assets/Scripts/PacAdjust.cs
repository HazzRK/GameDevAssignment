using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacAdjust : MonoBehaviour
{
    //private Transform PacTransform;
    //public Animator animatorController;
    [SerializeField]
    private GameObject item;

    private Tweener tweener;

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        //PacTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Quaternion target = Quaternion.Euler(0, 0, 90);
            //PacTransform.rotation = Quaternion.Slerp(PacTransform.rotation, target, 1);
            tweener.AddTween(item.transform, item.transform.position, new Vector3(-36.0f, 41f, 0.0f), 1.5f);
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //Quaternion target = Quaternion.Euler(0, 0, -90);
            //PacTransform.rotation = Quaternion.Slerp(PacTransform.rotation, target, 1);
            tweener.AddTween(item.transform, item.transform.position, new Vector3(-20.0f, 28f, 0.0f), 1.5f);
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Quaternion target = Quaternion.Euler(0, 0, 0);
            //PacTransform.rotation = Quaternion.Slerp(PacTransform.rotation, target, 1);
            //PacTransform.localScale = new Vector3(1, 1, 1);
            tweener.AddTween(item.transform, item.transform.position, new Vector3(-20.0f, 41f, 0.0f), 1.5f);
        } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Quaternion target = Quaternion.Euler(0, 0, -180);
            //PacTransform.rotation = Quaternion.Slerp(PacTransform.rotation, target, 1);
            //PacTransform.localScale = new Vector3(1, -1, 1);
            tweener.AddTween(item.transform, item.transform.position, new Vector3(-36.0f, 28f, 0.0f), 1.5f);
        }
    }
}
