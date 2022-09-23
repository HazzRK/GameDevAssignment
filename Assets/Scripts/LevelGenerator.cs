using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    private int[,] levelMap =
         {
         {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
         {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
         {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
         {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
         {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
         {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
         {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
         {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
         {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
         {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
         {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
         {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
         {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
         {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
         {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
         };

    [SerializeField]
    private GameObject[] LevelPieces = new GameObject[8];
    private GameObject[,] topLeft;
    private Transform AutoLevelTransform;

    // Start is called before the first frame update
    void Start()
    {
        topLeft = new GameObject[levelMap.GetLength(0), levelMap.GetLength(1)];
        AutoLevelTransform = GetComponent<Transform>();
        LevelPieces[0] = null;
        for (int i = 0; i<levelMap.GetLength(0);i++)
        {
            for (int a = 0; a<levelMap.GetLength(1);a++)
            {
                if (levelMap[i,a] == 0)
                {
                    topLeft[i, a] = null;
                } else
                {
                    Vector3 pos = new Vector3(a*3.2f, i*-3.2f, 0f);
                    
                    Debug.Log("i=" + i + " a=" + a);
                    Debug.Log("levelMap value = " + levelMap[i,a]);
                    topLeft[i, a] = Instantiate(LevelPieces[levelMap[i, a]], pos, Quaternion.identity, AutoLevelTransform);
                }
            }
        }
        AutoLevelTransform.position = new Vector3(70f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
