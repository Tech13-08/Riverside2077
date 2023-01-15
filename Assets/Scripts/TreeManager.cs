using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    public GameObject treeSpawn;
    public PlayerManager playerInv;

    public int numTrees = 0;
    // Update is called once per frame
    void Update()
    {
        if(playerInv.inventory.HasAtLeast(ItemType.PLANT_SAPLING, 1) && Input.GetKeyDown(KeyCode.T)){
            Vector2 pos = GameObject.FindWithTag("Player").transform.position;
            Vector2 offset = new Vector2(0.05f,0.05f);
            Instantiate(treeSpawn, pos + offset, Quaternion.identity);
            playerInv.inventory.Remove(ItemType.PLANT_SAPLING, 1);
            numTrees++;
        }
    }
}
