using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataControll : MonoBehaviour
{
    private static DataControll instance;
    private int m_gold;
    private int m_golodPerClick;
    public static DataControll GetInstance() 
    {
        if (instance == null) 
        {
            instance = FindObjectOfType<DataControll>();

            if (instance == null) 
            {
                GameObject container = new GameObject("DataController");

                container.AddComponent<DataControll>();
            }
        }

        return instance;
    }

    private void Awake()
    {   
        //로컬에 저장
        m_gold = PlayerPrefs.GetInt("Gold");
        m_golodPerClick = PlayerPrefs.GetInt("GoldPerClick", 1);
    }

    public void SetGold(int newGold) 
    {
        //로컬에 저장 save
        m_gold = newGold;
        PlayerPrefs.SetInt("Gold", m_gold);
    }
    public void state() 
    {

        print("gg");

    }


}
