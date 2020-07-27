using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_2 : MonoBehaviour
{
    public const int MORNING_SCHOOL = 1;    //朝
    public const int NOON_SCHOOL = 2;       //昼
    public const int EVENING_SCHOOL = 3;    //夕方

    public GameObject schoolPanels;

    public const int MAN_A = 1;
    public int count = 0;   //話しかけた回数
    public bool endDay = false; //夕方に3回話した後か

    int schoolNo;
    
    // Start is called before the first frame update
    void Start()
    {
        schoolNo = MORNING_SCHOOL;  //スタート時は朝
    }

    // Update is called once per frame
    void Update()
    {
        if (endDay==true)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    void DisplayWalls()
    {
        switch (schoolNo)
        {
            case MORNING_SCHOOL:
                schoolPanels.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                break;
            case NOON_SCHOOL:
                schoolPanels.transform.localPosition = new Vector3(-850.0f, 0.0f, 0.0f);
                break;
            case EVENING_SCHOOL:
                schoolPanels.transform.localPosition = new Vector3(-1700.0f, 0.0f, 0.0f);
                break;
        }
    }

    public void PushHuman()
    {
        if (count == 3)
        {
            if (schoolNo == EVENING_SCHOOL)
            {
                endDay = true;
            }
            else
            {
                schoolNo++;
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
