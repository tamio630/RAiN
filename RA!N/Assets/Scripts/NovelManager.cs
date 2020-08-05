using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NovelManager : MonoBehaviour
{
    private Text targetText;
    private string[] yuya = { "\nHello\n", "\nゆうやだよ\n", "\nじゃあね\n" };
    public int yuya_flag = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            printText();
            yuya_flag++;
            /*SceneManager.LoadScene("GameScene");*/

        }
    }

    void printText()
    {
        this.targetText = this.GetComponent<Text>();
        switch (yuya_flag)
        {
            case 0:
                this.targetText.text = yuya[0];
                break;
            case 1:
                this.targetText.text = yuya[1];
                break;
            case 2:
                this.targetText.text = yuya[2];
                break;
        }
    }
}
