using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelManager : MonoBehaviour
{
    public GameObject labels;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)){
            ToggleLabels();
        }
    }

    void ToggleLabels(){
        if(!labels.activeSelf){
            labels.SetActive(true);
        }
        else{
            labels.SetActive(false);
        }
    }
}
