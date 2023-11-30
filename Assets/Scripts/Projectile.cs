using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using ScriptableObjects;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float damage; 
    [SerializeField] private float shootForce; 
    [SerializeField] private Rigidbody rb; 
    private float trueDamage; 

    public void Init(float ChargePercent, Vector3 fireDirection){
        rb.AddForce(shootForce * ChargePercent * fireDirection, ForceMode.Impulse); 
        trueDamage = ChargePercent * damage; 
    }
    private void OnCollisionEnter(Collision other){
    

        print(other.transform.name + ", " + other.transform.root.name);

        if(other.transform.root.TryGetComponent(out IDamagable hitTarget)){

            switch (other.transform.tag){
                case "Head" : 
                trueDamage *= 2f; 
                break;

                case "Limb":
                trueDamage *= 0.8f; 
                break; 

            }
            print("has taken " + trueDamage + " Dmg"); 
            hitTarget.TakeDamage(trueDamage); 
        }

        Destroy(gameObject); 


    }
}
