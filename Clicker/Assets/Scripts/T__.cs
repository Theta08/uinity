using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T__ : MonoBehaviour
{
    public Text Turn_test;           //턴 시작 종료 텍스트
    public Text Turn_sub_test;
    public Text battle_text_;
    public Text Turn;
    public GameObject player_obj2;

    //public DataControll DataControll;

    private bool my_trun;       //턴 제할때 사용 t면 내턴 f면 상대 턴
    private Monster_ monster;
    private P__ stat;

    int currentHp;
    int player_hp;
    int player_def;
    int player_damage;

    int enemy_hp = 0;
    int enemy_def;
    int enemy_damge;
    int turn;

    public Text player_hp_text;
    public Text enemy_hp_text;

    void Start()
    {
        my_trun = true;
        monster = FindObjectOfType<Monster_>();
        stat = FindObjectOfType<P__>();


        player_hp = stat.hp;
        player_def = stat.def;

        /* player_hp2 = stat.hp2;
         player_def2 = stat.def2;

         player_hp2 = stat.hp3;
         player_def2 = stat.def3;*/

        enemy_hp = monster.hp;
        enemy_def = monster.def;
        enemy_damge = monster.atk;

        StartCoroutine(Ready());
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Info(string infoText)
    {
        switch (infoText)
        {
            case "TurnChang":
                if (my_trun == true)
                {
                    Turn_test.text = "내 턴";
                }
                else
                {
                    Turn_test.text = "상대 턴";
                }
                break;
            case "GameStart":
                Turn_test.text = "내 턴";
                break;
            case "CostInit":
                Turn_sub_test.text = "비용 초기화";      //버프,디버프,스킬 쿨타임 확인 ->버프 줄이기_계산
                break;
            case "BeginAct":
                Turn_sub_test.text = "시작 효과 발동";   //버프,디버프 발동
                break;
            case "Act":
                Turn_sub_test.text = "행동";              //스킬 선택,뎀이지 계산, 디버프,버프 초상화 적용
                break;
            case "AfterAct":
                Turn_sub_test.text = "종료 효과 발동";    //종료
                break;
            case "GameOver":
                Turn_test.text = "패배";
                break;
            case "Win":
                Turn_test.text = "승리";
                break;
        }



    }
    //--------코루틴 함수-----------------------
    IEnumerator Ready()
    {
        battle_text_.text = "" + 3;
        yield return WaitToResumeGame();
        battle_text_.text = "" + 2;
        yield return WaitToResumeGame();
        battle_text_.text = "" + 1;
        yield return WaitToResumeGame();
        battle_text_.text = "READY";
        yield return WaitToResumeGame();

        Time.timeScale = 1f;

        GameStart();

    }

    IEnumerator WaitToResumeGame()
    {
        float start = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < start + 1f)
        {
            yield return 0;
        }
    }
    //----------------------------------------------------------------------
    public void GameStart()                 //게임 시작
    {
        Info("GameStart");
        //택스트 초기화
        player_hp_text.text = string.Format("HP: {0}", player_hp);
        enemy_hp_text.text = string.Format("HP: {0}", enemy_hp);
        Turn.text = "턴 표시 테스트";


        CostInit();
    }
    public void CostInit()                  //비용 초기화
    {
        Info("CostInit");
        Invoke("BeignAct", 0.7f);            //시간 지연 코루틴
    }
    public void BeignAct()                  //시작 효과 발동
    {
        Info("BeignAct");
        Invoke("Act", 0.8f);
    }
    public void Act()                      // 행동
    {
        Info("Act");
        if (!my_trun)
        {
            //몬스터 공격
            //enemy_damge = monster.Choice_Skill(enemy_damge); // 몬스터 공격 패턴 넣기
            enemy_damge = monster.Choice_Skill(enemy_damge);
            Debug.Log("플레이어 때리기전 " + enemy_damge);
            //여기 3명중 한명 때리기
            int ran_player = monster.Choice_player();
            switch (ran_player)
            {
                case 0:
                    stat.Hit(enemy_damge);
                    Chick();
                    break;
                case 1:
                    stat.Hit(enemy_damge);
                    Chick();
                    break;
                case 2:
                    stat.Hit(enemy_damge);
                    Chick();
                    break;

            }
            //======================
            stat.Hit(enemy_damge);                      //몬스터 뎀이지-플레이어 방어력
            Chick();
            //player_hp = Attack(player_hp);
            // player_hp_text.text = string.Format("HP: {0}", enemy_damge);
            Invoke("AfterAct", 0.8f);
        }
        else
        {
            turn++;         //턴표시
            Turn.text = string.Format("턴 {0}", turn);
            player_obj2.SetActive(true);
        }

    }
    public void AfterAct()                  //종료 효과 발동
    {
        Info("AfterAct");
        Invoke("TurnChang", 0.75f);
    }
    //======================================================
    public void Skill_Button0()
    {
        player_obj2.SetActive(false);
        // 플레이어 공격
        // enemy_hp=stat.Hit(enemy_hp);             //방어력 무시       
        enemy_def = stat.Choice_Skill(enemy_def, 0);    //스킬-적방어력,스킬 선택
        enemy_hp = monster.Def(enemy_def);            //HP-스킬_뎀이지
                                                      // enemy_hp_text.text = string.Format("HP:{0}", enemy_hp);
        Turn_test.text = "턴 종료";
        Debug.Log("====턴 종료========");

        AfterAct();
    }
    public void Skill_Button1()
    {
        enemy_def = stat.Choice_Skill(enemy_def, 0);
        enemy_hp = monster.Def(enemy_def);
        Turn_test.text = "턴 종료";
        Debug.Log("====턴 종료========");
        player_obj2.SetActive(false);
        AfterAct();
    }

    public void Skill_Button2()
    {
        enemy_def = stat.Choice_Skill(enemy_def, 1);
        enemy_hp = monster.Def(enemy_def);
        Turn_test.text = "턴 종료";
        Debug.Log("====턴 종료========");
        player_obj2.SetActive(false);
        AfterAct();
    }

    public void TurnChang()
    {
        my_trun = !my_trun;
        Info("TurnChang");
        CostInit();
    }
    //=========================================================
    // 승리 or 패배시 멈춤
    public void GameOver()
    {
        Info("GameOver");
        Time.timeScale = 0;
    }

    public void Win()
    {
        Info("Win");
        Time.timeScale = 0;
    }
    //승리 패패 체크
    public void Chick()
    {
        if (stat.currentHp <= 0)
        {
            if (my_trun)
            {
                Win();
            }
            else
            {

                GameOver();
            }

        }
    }
}
