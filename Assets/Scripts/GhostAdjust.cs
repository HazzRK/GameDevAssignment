using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAdjust : MonoBehaviour
{
    public Animator animatorController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animatorController.SetTrigger("GhostUpParam");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animatorController.SetTrigger("GhostLeftParam");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animatorController.SetTrigger("GhostDownParam");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animatorController.SetTrigger("GhostRightParam");
        } else if (Input.GetKeyDown(KeyCode.Space))
        {
            animatorController.SetTrigger("GhostScaredParam");
        }
    }
}
