using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeInvisible : MonoBehaviour
{
    public int flag;
    // Start is called before the first frame update
    void Start()
    {
        if (flag==0)
        {
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 225, 0);
        } else if(flag==1)
        {
            // gameObject.GetComponent<Text>().color = new Color(0,0,0,0); // makes a null reference exception so I manually set the alpha value in inspector
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
