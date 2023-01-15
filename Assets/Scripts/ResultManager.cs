using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultManager : MonoBehaviour
{
    public GameObject passed;
    public GameObject failed;

    public TextMeshProUGUI co2Percent;

    public TextMeshProUGUI plasticPercent;

//    void Update()
//     {
//         if(float.TryParse(co2Percent.text.Remove(co2Percent.text.Length - 1, 1), out float co2)){
//             if(int.TryParse(plasticPercent.text.Remove(plasticPercent.text.Length - 1, 1), out int plastic)){
//                 if(co2 > 100.0f || plastic > 100){
//                     failed.SetActive(true);
//                 }
//                 else if(co2 < 5 && plastic < 100){
//                     passed.SetActive(true);
//                 }
//             }
//         }
//     }
}
