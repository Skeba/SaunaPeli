 using UnityEngine;
 
  public class DestroyPlayer : MonoBehaviour {

void OnCollisionEnter2D (Collision2D col){
     if(col.gameObject.tag == "Player")
     Destroy(col.gameObject);
     }
 }