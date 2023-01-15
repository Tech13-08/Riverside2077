using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CO2Manager : MonoBehaviour
{
    public TreeManager treeManager;

    public TextMeshProUGUI percentText;

    float newPercent = 0f;

    float initialPercent;

    // Update is called once per frame
    private float treeTime = 0.0f;
    public float treePeriod = 1f;
    void Update () {
        treeTime += Time.deltaTime;
        if (treeTime >= treePeriod) {
            treeTime = 0.0f;
            if(float.TryParse(percentText.text.Remove(percentText.text.Length - 1, 1), out initialPercent)){
                newPercent = initialPercent - (0.001f*treeManager.numTrees);
                if(newPercent >= 0){
                    percentText.text = newPercent.ToString("0.00") + "%";
                }
                if(Random.Range(1,5) == 3){
                    percentText.text = (initialPercent + (0.05f*(treeManager.numTrees/2) + 0.01f)).ToString("0.00") + "%"; 
                }
            }
            else{
                Debug.Log("Failed");
            }
        }
        
    }
}
