using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_2 : MonoBehaviour
{
    public const int MAN_A = 1;
    public int count = 0;   //話しかけた回数
    public int week = 0;    //何週回ったか

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushHuman()
    {
        count++;
        Debug.Log(count);
        if (count == 3)
        {
            week++;
            count = 0;
            SceneManager.LoadScene("EndScene");
        }

        if (week == 6 && count == 2)
        {
            //雨の背景にする
        }

    }
}
