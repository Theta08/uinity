using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Shuff : MonoBehaviour
{
    public static S_Shuff instance;
    
    //[HideInInspector]
    public int hp;
    public int atk;
    public int def;
    public int m_def;
    public int m_atk;
    public int critical;

    [HideInInspector]
    public int level = 0;
    int count;
    int n;
    
    private void Start()
    {

        instance = this;
        hp = 500;
        atk = 150;
        def = 40;
        m_def = 15;
        m_atk = 0;
        critical = 40;
    }
    public void level_atk_n(int level_) 
    {
        /*level = level_;
        switch (level) 
        {
            case level > 0:
                n = 2;
                break;
            case level > 15:
                n = 4;
                break;
        }*/
            
    }
    public int Sord_attack(int Play_atk) 
    {
        
        return Play_atk;
    }

    public void PowerAtk(int Play_atk) 
    {
        Play_atk = Play_atk * 2;
        int buf_count = 3;

    }
    //스킬 쿨타임 4
    public void Sim(int Play_atk) 
    {
        //Play_atk = Play_atk * n;
        //실험
        Play_atk = Play_atk * 3;
        Debug.Log("스킬 쿨 카운트 세기 전: " + count);
        count++;
        Debug.Log("스킬 쿨 카운트: " + count);
        if (count == 4)
            count = 0;
    }
}
