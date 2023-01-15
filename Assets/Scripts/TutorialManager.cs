using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorial;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H)){
            ToggleStats();
        }
    }

    void ToggleStats(){
        if(!tutorial.activeSelf){
            tutorial.SetActive(true);
        }
        else{
            tutorial.SetActive(false);
        }
    }
}
