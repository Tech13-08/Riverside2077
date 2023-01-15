using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject miniMap;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            ToggleStats();
        }
    }

    void ToggleStats(){
        if(!miniMap.activeSelf){
            miniMap.SetActive(true);
        }
        else{
            miniMap.SetActive(false);
        }
    }
}
