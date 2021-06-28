using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    //[SerializeField] private Slider slider;
    public static PlayerStat instance;  //다른 곳에서 쓰기위해

    private S_Shuff s_player;
    /*int[] hp= new int[3];              //전체 hp
    int[] def=new int[3];
    int[] atk=new int[3];*/

    
    public int hp;              //전체 hp
    public int def;
    public int mdef;
    public int atk;
    public int matk;
    public int level;

    [HideInInspector]
    public int count=0;
    [HideInInspector]
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
        stat();
        //hp: 텍스트
        //hp_text.text = string.Format("HP: {0}", hp);
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
        matk = s_player.m_atk;
        def = s_player.def;
        mdef = s_player.m_def;
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
        Debug.Log("몬스터의 순수 뎀이지:"+_enemyAtk);
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
        Debug.Log("플레이어가 주는 뎀이지: "+enem);

        return enem;
    }
    public int Choice_Skill(int enem,int selelct)
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
        enem += 10;
        Debug.Log("Skill_1 플레이어가 주는 뎀이지: " + enem);
        return enem;
    }
    //3스킬 쿨타임 3_실험
    public int Skill_2(int enem)
    {
        enem += 30;
        Debug.Log("Skill_2 플레이어가 주는 뎀이지: " + enem);
        skill_count++;
        if (skill_count == 3)
            skill_count = 0;

        return enem;
    }
    public int Skill_3(int enem)
    {
        enem += 40;
        Debug.Log("Skill_3 플레이어가 주는 뎀이지: " + enem);
        return enem;
    }
    // Test 쿨타임
    public void Cooldown() 
    {
        if (count > 0) 
        {
            skill_count++;

        }
    }
}
