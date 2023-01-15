using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public GameObject stats;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            ToggleStats();
        }
    }

    void ToggleStats(){
        if(!stats.activeSelf){
            stats.SetActive(true);
        }
        else{
            stats.SetActive(false);
        }
    }
}
