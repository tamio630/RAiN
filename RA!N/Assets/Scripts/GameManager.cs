using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    Text scenarioMessage;
    List<Scenario> scenarios = new List<Scenario>();

    Scenario currentScenario;
    int index = 0;

    public const int MAN_A = 1;
    public int count = 1;   //話しかけた回数
    public int week = 0;    //何週回ったか
    public bool isText = true; //テキスト表示中か

    class Scenario
    {
        public string ScenarioID;
        public List<string> Texts;
        public List<string> Options;
        public string NextScenarioID;
    }

    // Start is called before the first frame update
    void Start()
    {
        var scenario01 = new Scenario()
        {
            ScenarioID = "scenario01",
            Texts = new List<string>()
            {
                "",
                "グラブル命！！！",
                "うちはまだ廃人じゃない！！！",
                "テスト終了です"
            }
        };
        SetScenario(scenario01);
}

    // Update is called once per frame
    void Update()
    {
        if (currentScenario != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isText = true;
                SetNextMessage();
            }
        }
        else
        {
            isText = false;
        }
    }

    void SetScenario(Scenario scenario)
    {
        currentScenario = scenario;
        scenarioMessage.text = currentScenario.Texts[0];
    }

    void SetNextMessage()
    {
        if (currentScenario.Texts.Count > index + 1)
        {
            index++;
            scenarioMessage.text = currentScenario.Texts[index];
        }
        else
        {
            ExitScenario();
        }
    }

    void ExitScenario()
    {
        scenarioMessage.text = "";
        index = 0;
        if (string.IsNullOrEmpty(currentScenario.NextScenarioID))
        {
            currentScenario = null;
        }
        else
        {
            var nextScenario = scenarios.Find
                (s => s.ScenarioID == currentScenario.NextScenarioID);
            currentScenario = nextScenario;
        }
    }

    public void PushHuman()
    {
        if (isText==false)
        {
            count++;
            Debug.Log(count);
            if (count == 3)
            {
                week++;
                count = 0;
                SceneManager.LoadScene("EndScene");
            }
        }

        if(week==6 && count == 2)
        {
            //雨の背景にする
        }
        
    }
}
