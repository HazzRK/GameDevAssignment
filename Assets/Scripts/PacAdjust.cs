using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacAdjust : MonoBehaviour
{
    private Transform PacTransform;
    public Animator animatorController;
    // Start is called before the first frame update
    void Start()
    {
        PacTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Quaternion target = Quaternion.Euler(0, 0, 90);
            PacTransform.rotation = Quaternion.Slerp(PacTransform.rotation, target, 1);
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Quaternion target = Quaternion.Euler(0, 0, -90);
            PacTransform.rotation = Quaternion.Slerp(PacTransform.rotation, target, 1);
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Quaternion target = Quaternion.Euler(0, 0, 0);
            PacTransform.rotation = Quaternion.Slerp(PacTransform.rotation, target, 1);
            PacTransform.localScale = new Vector3(1, 1, 1);
        } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Quaternion target = Quaternion.Euler(0, 0, -180);
            PacTransform.rotation = Quaternion.Slerp(PacTransform.rotation, target, 1);
            PacTransform.localScale = new Vector3(1, -1, 1);
        } else if (Input.GetKeyDown(KeyCode.Space))
        {
            animatorController.SetTrigger("DeathParam");
        }
    }
}
