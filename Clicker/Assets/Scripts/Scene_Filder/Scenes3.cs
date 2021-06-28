using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scenes3 : MonoBehaviour
{
    public string Denguen;        //다음씬으로 갈 이름
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Click()
    {
        SceneManager.LoadScene(Denguen);  //Main으로
    }
}
