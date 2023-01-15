using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlasticManager : MonoBehaviour
{
    public GameObject plasticSpawn;
    public PlayerManager player;

    public TextMeshProUGUI percentText;

    public List<Vector2> positions = new List<Vector2>();

    private float plasticTime = 0.0f;

    public float plasticPeriod = 0.05f;

    int newPercent = 0;

    int initialPercent;

    public int numPlastic = 0;

    int prevPlayerNumPlastic = 0;

    int currPlayerNumPlastic = 0;

    // Update is called once per frame
    void Update()
    {   
        plasticTime += Time.deltaTime;
        currPlayerNumPlastic = player.inventory.ItemCount(ItemType.PLASTIC);
        if(currPlayerNumPlastic > prevPlayerNumPlastic){
            numPlastic -= (currPlayerNumPlastic-prevPlayerNumPlastic);
            prevPlayerNumPlastic = currPlayerNumPlastic;
        }
        else if(currPlayerNumPlastic < prevPlayerNumPlastic){
            prevPlayerNumPlastic = currPlayerNumPlastic;
        }
        newPercent = numPlastic*10;
        if(newPercent >= 0){
            percentText.text = newPercent.ToString() + "%";
        }
        if(plasticTime >= plasticPeriod){
            plasticTime = 0.0f;
            //Debug.Log("0.25s...");
            if(Random.Range(1,3) == 2){
                //Debug.Log("Spawning plastic...");
                Vector2 pos = positions[Random.Range(0, 8)];
                Vector2 offset = new Vector2(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f));
                //Debug.Log("Spawning at: " + (pos+offset));
                Instantiate(plasticSpawn, pos + offset, Quaternion.identity);
                numPlastic++;
            }
            newPercent = numPlastic*10;
            if(newPercent >= 0){
                percentText.text = newPercent.ToString() + "%";
            }
        }
    }
}
