using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour, IDamagable
{
    [field: SerializeField] public float Health {get; set; }
    [SerializeField] private float speed; 
    private Rigidbody _rb; 
    private void Awake(){

        _rb = GetComponent<Rigidbody>(); 

    }
    private void Update(){
        _rb.AddForce(Vector3.forward * speed); 

    }
    public void Die(){
        
        Destroy(gameObject); 


    }

}
