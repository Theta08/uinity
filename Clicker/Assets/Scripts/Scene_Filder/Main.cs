using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public string mainScene;        //다음씬으로 갈 이름

    // Start is called before the first frame update
    void Start()
    {
        
    }



    public void Click() {
        SceneManager.LoadScene(mainScene);  //Main으로
    }
}
