 using UnityEngine;
 
  public class DestroyCoins : MonoBehaviour {

void OnCollisionEnter2D (Collision2D col){
     if(col.gameObject.tag == "Coin")
     Destroy(col.gameObject);
     }
 }