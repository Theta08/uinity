using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Monster_ : MonoBehaviour
{
    //[SerializeField] private Slider slider;
    public static Monster_ instance;    //다른 곳에서 쓰기위해

    public Text enemy_hp_text;

    public int hp;                  //전제 hp
    public int currenthp;            //현제 hp
    public int def;                 //방어력
    public int atk;
    public int damage;
    int count;                      //특수 패턴 세기
    private void Start()
    {
        instance = this;
        currenthp = hp;
        damage = atk;
    }
    private void Update()
    {
        //damage = atk;
    }
    //--------------------몬스터 스킬---------------------------
    public int Attack1(int damage_) 
    {
        //damage += 20;
        damage_ += 20;
        //damage_ = damage;
        Debug.Log("몬스터가 skill 1 :" + damage_ + "주었다.!");
        

        return damage_;
   
    }

    public int Attack2(int damage_)
    {
        damage_ += 10;
        Debug.Log("몬스터가 skill 2 :" + damage_ + "주었다.!");

        return damage_;

    }

    public int Attack3(int damage_)
    {
       
        damage_ +=40 ;
        Debug.Log("몬스터가 skill 3 :" + damage_ + "주었다.!");

        return damage_;

    }
    //패시브
    public int Passive()
    {

        def = 10;
        Debug.Log("Passive 발동!" + def + " 방어력");

        return def;

    }
    //특수패턴
    public void Scpcial() 
    {
        damage += 30;
        def -= 10;
        
        
    }

    public int Def(int player_atk) 
    {
        Debug.Log("몬스터 방어력 계산 전: "+ player_atk);
        int dmg;
        if (def >= player_atk)
        {
            dmg = 0;
        }
        else 
        {
            dmg = player_atk - def;
        }
        currenthp -= dmg;
        player_atk = dmg;

        Debug.Log("몬스터 :방어력 계산 후: " + player_atk);

        enemy_hp_text.text = string.Format("HP:{0}", currenthp);

        return player_atk;
    }

    //공격할 플레이어 선택
    public void Choice_Target() 
    {
        //플레이어 랜덤 선택
        int pick = Random.Range(0, 0);
    }

    //스킬 선택
    public int Choice_Skill(int damage_)
    {
        count++;
        Debug.Log("몬스터 카운터(턴) 체크: " + count);
        int pick = Random.Range(0, 3);
        Debug.Log("들어온 damage_ 1: " + damage_);
        damage_ = atk;
        Debug.Log("들어온 damage_ 2: " + damage_);
        if (currenthp <= hp/2)
        {

            switch (count) 
            {
                case 1: 
                    Debug.Log("특수 패턴!!");
                    Scpcial();
                    break;

                /*case 2:
                    Debug.Log("특수 패턴!!");
                    Scpcial();
                    break;*/
            }
            
        }
        if (count % 3 == 0) 
        {
            Passive();
        }
        
        switch (pick) 
        {
            case 0:
                damage_ =Attack1(damage_);
                Debug.Log("몬스터 스킬 공격1: " + damage_);
                break;
            case 1:
                damage_ =Attack2(damage_);
                Debug.Log("몬스터 스킬 공격2: " + damage_);
                break;
            case 2:
                damage_ =Attack3(damage_);
                Debug.Log("몬스터 스킬 공격3: " + damage_);
                break;

        }
        
        return damage_;
        
    }
    public int Choice_player() 
    {
        int player = Random.Range(0, 3);
        return player;
    }
}
