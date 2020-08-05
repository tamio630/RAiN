using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_2 : MonoBehaviour
{
    
    public const int MORNING_SCHOOL = 1;    //朝の教室
    public const int NOON_SCHOOL = 2;       //昼の教室
    public const int EVENING_SCHOOL = 3;    //夕方の教室
    public const int MORNING_STAIRS = 4;    //朝の階段
    public const int NOON_STAIRS = 5;       //昼の階段
    public const int EVENING_STAIRS = 6;    //夕方の階段
    public int[ , ] BackGrounds = new int[ , ] 
    {
        { MORNING_SCHOOL, NOON_SCHOOL, EVENING_SCHOOL },
        { MORNING_STAIRS, NOON_STAIRS, EVENING_STAIRS }
    };

    public GameObject schoolPanels;

    public const int MAN_A = 1;
    public int count = 0;   //話しかけた回数
    public bool endDay = false; //夕方に3回話した後か

    int schoolNo;
    int schoolRow;
    int schoolCol;

    // Start is called before the first frame update
    void Start()
    {
        //スタート時は朝
        schoolRow = 0;
        schoolCol = 0;
        schoolNo = MORNING_SCHOOL;
    }

    // Update is called once per frame
    void Update()
    {
        if (endDay==true)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    int CalcRowNumber(int back)
    {
        double ans = back * ((double)2 / 3) + ((double)1 / 3);
        return (int)(back-ans);
    }

    int CalcColNumber(int back)
    {
        int x,ans=0;
        x = back % 3;
        switch (x)
        {
            case 0:
                ans = 2;
                break;
            case 1:
                ans = 0;
                break;
            case 2:
                ans = 1;
                break;
        }
        return ans;
    }

    public void PushButtonRight()
    {
        schoolRow++;    //1行下の背景に行く
        if (schoolRow > CalcRowNumber(EVENING_STAIRS))   //画像番号から行を求める
                                                         //school:0 starts:1
        {
            schoolRow = CalcRowNumber(MORNING_SCHOOL);
        }
        DisplayWalls();
    }

    public void PushButtonLeft()
    {
        schoolRow--;    //1つ上の背景に行く
        if (schoolRow < CalcRowNumber(MORNING_SCHOOL))
        {
            schoolRow = CalcRowNumber(EVENING_STAIRS);
        }
        DisplayWalls();
    }

    void DisplayWalls()
    {
        switch (BackGrounds[schoolRow,schoolCol])
        {
            case MORNING_SCHOOL:
                schoolPanels.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                break;
            case NOON_SCHOOL:
                schoolPanels.transform.localPosition = new Vector3(-1920.0f, 0.0f, 0.0f);
                break;
            case EVENING_SCHOOL:
                schoolPanels.transform.localPosition = new Vector3(-3840.0f, 0.0f, 0.0f);
                break;
            case MORNING_STAIRS:
                schoolPanels.transform.localPosition = new Vector3(0.0f, 1080.0f, 0.0f);
                break;
            case NOON_STAIRS:
                schoolPanels.transform.localPosition = new Vector3(-1920.0f, 1080.0f, 0.0f);
                break;
            case EVENING_STAIRS:
                schoolPanels.transform.localPosition = new Vector3(-3840.0f, 1080.0f, 0.0f);
                break;
        }
    }

    public void PushHuman()
    {
        if (count == 3)
        {
            if (schoolCol == 2)
            {
                endDay = true;
            }
            else
            {
                schoolCol++;
                DisplayWalls();
            }
            count = 0;
        }
        else
        {
            count++;
        }

        /*count++;
        Debug.Log(count);
        if (count == 3)
        {
            count = 0;
            SceneManager.LoadScene("EndScene");
        }*/
    }
}
