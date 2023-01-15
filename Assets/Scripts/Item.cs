using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType type;
    public ItemType itemTypeRequired;
    public Sprite icon;

    public int buck = 0;
    public int bang = 0;

    public TransactionType transactionType;

    bool colliding = false;

    PlayerManager player;

    void Update(){
        if(colliding && Input.GetKeyDown(KeyCode.E)){
            if(transactionType == TransactionType.SELLER && player.inventory.HasAtLeast(itemTypeRequired, buck)){
                player.inventory.Add(this, bang);
                player.inventory.Remove(itemTypeRequired, buck);
            }
            else if(transactionType == TransactionType.BUYER && player.inventory.HasAtLeast(itemTypeRequired, buck)){
                player.inventory.Add(this, bang);
                player.inventory.Remove(itemTypeRequired, buck);
            }
            else if(transactionType == TransactionType.COLLECTOR){
                player.inventory.Add(this, bang);
                Destroy(gameObject);
            }
            colliding = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        player = collision.GetComponent<PlayerManager>();

        if(player){
            colliding = true;
        }
    }
}

public enum ItemType{
    NONE, PLANT_SAPLING, BEAR_BUCKS, PLASTIC
}

public enum TransactionType{
    SELLER, BUYER, COLLECTOR
}