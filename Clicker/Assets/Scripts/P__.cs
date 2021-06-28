using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class P__ : MonoBehaviour
{
    //[SerializeField] private Slider slider;
    public static P__ instance;  //다른 곳에서 쓰기위해

    public GameObject p2_2;
    private S_Shuff s_player;
    private Monster_ monster;
    /*int[] hp= new int[3];              //전체 hp
    int[] def=new int[3];
    int[] atk=new int[3];*/

    public int hp;              //전체 hp
    public int def;
    public int m_def;
    public int atk;
    public int m_atk;
    public int level;

    public int count = 0;
    public int skill_count = 0;
    public float currentHp;       //현제 hp


    public Slider hpSlider;     //hp1
    public Text hp_text;
  

    private bool isClick;

    private float dotTime = 1f;
    private float currentDotTime = 0f;

    void Start()
    {
        instance = this;
        s_player = FindObjectOfType<S_Shuff>();
        monster = FindObjectOfType<Monster_>();

        stat();
        currentHp = hp;
        currentDotTime = dotTime;
        //hp_text.text=;
    }

    void Update()
    {

        hpSlider.maxValue = hp;
        hpSlider.value = currentHp;



        //지속 뎀이지 실험
        if (isClick)
        {
            currentDotTime -= Time.deltaTime;   //1초에 1식담

            if (currentDotTime <= 0)
            {
                currentHp -= Time.deltaTime;    //실수
                if (currentDotTime <= -1f)
                {
                    currentDotTime = dotTime;
                }

            }

        }

    }

    void stat()
    {
        hp = s_player.hp;
        atk = s_player.atk;
        m_atk = s_player.m_atk;
        def = s_player.def;
        m_def = s_player.m_def;
    }
    public void Button()
    {


        currentHp -= 1;     //체력이 -1 줄어듬
        if (currentHp == 0)
        {
            Debug.Log("0보다 작음");

        }
    }

    public void DotButton()
    {
        isClick = true;
    }

    //플레이어 피격 판정
    public void Hit(int _enemyAtk)
    {
        int dmg;
        Debug.Log("몬스터의 순수 뎀이지:" + _enemyAtk);
        if (def >= _enemyAtk)
        {
            dmg = 0;
            Debug.Log("받은 뎀이지:" + dmg);
        }
        else
            dmg = _enemyAtk - def;
        Debug.Log("받은 뎀이지:" + dmg);

        currentHp -= dmg;
        _enemyAtk = dmg;
        if (currentHp <= 0)
        {
            Debug.Log("체력 0 이하,게임 오버");
        }

        hp_text.text = string.Format("HP: {0}", currentHp);

        //return _enemyAtk;
    }

    //기본
    public int Damage(int enem)
    {
        //Debug.Log(enemHP);
        enem = atk;
        Debug.Log("플레이어가 주는 뎀이지: " + enem);

        return enem;
    }
    public int Choice_Skill(int enem, int selelct)
    {
        count++;
        Debug.Log("플레이어 카운터(턴) 체크: " + count);
        //int pick = Random.Range(0, 3);
        int pick = selelct;
        enem = atk;
        switch (pick)
        {
            case 0:
                enem = Skill_1(enem);
                Debug.Log("플레이어 스킬1: " + enem);
                break;
            case 1:
                enem = Skill_2(enem);
                Debug.Log("플레이어 스킬2: " + enem);
                break;
            case 2:
                enem = Skill_3(enem);
                Debug.Log("플레이어 스킬3: " + enem);
                break;
            default:                    //상태이상 한턴 쉬기
                break;
        }
        return enem;
    }
    //================================= 스킬=======
    public int Skill_1(int enem)
    {
        int atk_ = atk;
        enem= atk_ +10;
        Debug.Log("Skill_1 p2가 주는 뎀이지: " + enem);
        return enem;
    }
    //3스킬 쿨타임 3_실험
    public int Skill_2(int enem)
    {
        enem += 30;
        Debug.Log("Skill_2 p2 주는 뎀이지: " + enem);
        skill_count++;
        if (skill_count == 3)
            skill_count = 0;

        return enem;
    }
    public int Skill_3(int enem)
    {
        enem += 40;
        Debug.Log("Skill_3 p2 주는 뎀이지: " + enem);
        return enem;
    }
    // Test 쿨타임
   
    //버튼 실험
    public int P_Button1(int enem)
    {
        enem=Skill_1(enem);
        enem = monster.Def(enem);
        return enem;
    }

    public void P_B()
    {
        P_Button1(atk);
    }
}
