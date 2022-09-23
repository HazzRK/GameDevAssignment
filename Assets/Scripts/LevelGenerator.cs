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
        AutoLevelTransform.position = new Vector3(0f, 0f, 0f);
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
                    topLeft[i, a] = Instantiate(LevelPieces[levelMap[i, a]], pos, Quaternion.identity, AutoLevelTransform);
                }
            }
        }
        for (int i = 0; i < levelMap.GetLength(0); i++)
        {
            for (int a = 0; a < levelMap.GetLength(1); a++)
            {
                if (levelMap[i,a] == 1 | levelMap[i, a] == 2 | levelMap[i, a] == 3 | levelMap[i, a] == 4)
                {
                    bool up = false;
                    bool down = false;
                    bool right = false;
                    bool left = false;
                    int total = 0;
                    if (a>0)
                    {
                        if (levelMap[i, a - 1] == 1 | levelMap[i, a - 1] == 2 | levelMap[i, a - 1] == 3 | levelMap[i, a - 1] == 4)
                        {
                            left = true;
                            total++;
                        }
                    }
                    if (a < levelMap.GetLength(1)-1)
                    {
                        if (levelMap[i, a + 1] == 1 | levelMap[i, a + 1] == 2 | levelMap[i, a + 1] == 3 | levelMap[i, a + 1] == 4)
                        {
                            right = true;
                            total++;
                        }
                    }
                    if (i > 0)
                    {
                        if (levelMap[i -1, a] == 1 | levelMap[i-1, a] == 2 | levelMap[i-1, a] == 3 | levelMap[i-1, a] == 4)
                        {
                            up = true;
                            total++;
                        }
                    }
                    if (i < levelMap.GetLength(0)-1)
                    {
                        if (levelMap[i+1, a] == 1 | levelMap[i+1, a] == 2 | levelMap[i+1, a] == 3 | levelMap[i+1,a] == 4)
                        {
                            down = true;
                            total++;
                        }
                    }

                    if (levelMap[i, a] == 1 | levelMap[i, a] == 3) // corners
                    {
                        if (total == 2)
                        {
                            if (up==true&&right==true)
                            {
                                Quaternion target = Quaternion.Euler(0, 0, 90);
                                topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                            } else if (up==true&&left==true)
                            {
                                Quaternion target = Quaternion.Euler(0, 0, 180);
                                topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                            } else if (down==true&&left==true)
                            {
                                Quaternion target = Quaternion.Euler(0, 0, 270);
                                topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                            }
                        } else if (total == 3)
                        {
                            if (up==false)
                            {
                                if (levelMap[i,a+1]==1 | levelMap[i,a+1]==3)
                                {
                                    Quaternion target = Quaternion.Euler(0, 0, 270);
                                    topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                                }
                            } else if (right==false)
                            {
                                if (levelMap[i+1, a] == 1 | levelMap[i+1, a] == 3)
                                {
                                    Quaternion target = Quaternion.Euler(0, 0, 270);
                                    topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                                } else if (a+1==levelMap.GetLength(1))
                                {
                                    if (topLeft[i - 1, a].transform.rotation == Quaternion.Euler(0, 0, 0))
                                    {
                                        Quaternion target = Quaternion.Euler(0, 0, 180);
                                        topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                                    } else
                                    {
                                        Quaternion target = Quaternion.Euler(0, 0, 270);
                                        topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                                    }
                                } else
                                {
                                    Quaternion target = Quaternion.Euler(0, 0, 180);
                                    topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                                }
                            } else if (left==false)
                            {
                                if (levelMap[i-1, a] == 1 | levelMap[i-1, a] == 3)
                                {
                                    Quaternion target = Quaternion.Euler(0, 0, 90);
                                    topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                                }
                            } else if (down==false)
                            {
                                if (levelMap[i, a-1] == 1 | levelMap[i, a-1] == 3)
                                {
                                    Quaternion target = Quaternion.Euler(0, 0, 90);
                                    topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                                }
                                else
                                {
                                    Quaternion target = Quaternion.Euler(0, 0, 180);
                                    topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                                }
                            }
                        } else if (total == 1)
                        {
                            if (i==levelMap.GetLength(0)-1)
                            {
                                if (left==true)
                                {
                                    Quaternion target = Quaternion.Euler(0, 0, 270);
                                    topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                                }
                            } else if (a==levelMap.GetLength(1)-1)
                            {
                                if (up==true)
                                {
                                    Quaternion target = Quaternion.Euler(0, 0, 90);
                                    topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                                }
                            }
                        } else if (total == 4)
                        {
                            if (levelMap[i-1,a]==1|levelMap[i-1,a]==3)//up corner
                            {
                                if (topLeft[i,a-1].transform.rotation == Quaternion.Euler(0, 0, 90))
                                {
                                    Quaternion target = Quaternion.Euler(0, 0, 270);
                                    topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                                }
                            } else if (levelMap[i + 1, a] == 1 | levelMap[i + 1, a] == 3)//down corner
                            {
                                if (topLeft[i, a - 1].transform.rotation == Quaternion.Euler(0, 0, 90))
                                {
                                    Quaternion target = Quaternion.Euler(0, 0, 180);
                                    topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                                } else
                                {
                                    Quaternion target = Quaternion.Euler(0, 0, 90);
                                    topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                                }
                            } else if (levelMap[i, a-1] == 1 | levelMap[i, a-1] == 3) //left corner
                            {
                                if (topLeft[i-1, a].transform.rotation == Quaternion.Euler(0, 0, 0))
                                {
                                    Quaternion target = Quaternion.Euler(0, 0, 90);
                                    topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                                }
                            } else if (levelMap[i, a+1] == 1 | levelMap[i, a+1] == 3)//right corner
                            {
                                if (topLeft[i - 1, a].transform.rotation == Quaternion.Euler(0, 0, 0))
                                {
                                    Quaternion target = Quaternion.Euler(0, 0, 180);
                                    topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                                } else
                                {
                                    Quaternion target = Quaternion.Euler(0, 0, 270);
                                    topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                                }
                            }
                        }
                    } else // walls
                    {
                        if (total==2|total==3)
                        {
                            if (right == true && left == true)
                            {
                                Quaternion target = Quaternion.Euler(0, 0, 90);
                                topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                            } else if (total==2 && (right==true|left==true))
                            {
                                Quaternion target = Quaternion.Euler(0, 0, 90);
                                topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                            } 
                            
                        } else if (total == 1)
                        {
                            if (left==true|right==true)
                            {
                                Quaternion target = Quaternion.Euler(0, 0, 90);
                                topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                            }
                        }
                    }
                } else if (levelMap[i,a]==7)
                {
                    if (i==0 & a<levelMap.GetLength(1)-1)
                    {
                        if (levelMap[i,a+1]==2)
                        {
                            topLeft[i,a].transform.localScale = new Vector3(-1, 1, 1);
                        }
                    } else if (a==0)
                    {
                        if (i==levelMap.GetLength(0)-1)
                        {
                            topLeft[i, a].transform.localScale = new Vector3(-1, 1, 1);
                            Quaternion target = Quaternion.Euler(0, 0, 90);
                            topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                        } else
                        {
                            if (levelMap[i-1, a] == 2)
                            {
                                topLeft[i, a].transform.localScale = new Vector3(-1, 1, 1);
                                Quaternion target = Quaternion.Euler(0, 0, 90);
                                topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                            } else if (levelMap[i+1,a]==2)
                            {
                                Quaternion target = Quaternion.Euler(0, 0, 90);
                                topLeft[i, a].transform.rotation = Quaternion.Slerp(topLeft[i, a].transform.rotation, target, 1);
                            }
                        }
                    }
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
