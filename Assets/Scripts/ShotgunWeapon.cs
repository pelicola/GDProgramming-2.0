using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunWeapon : WeaponBase
{

    [SerializeField] private Rigidbody burstBullet; 
    [SerializeField] private Rigidbody burstBullet2; 
    [SerializeField] private Rigidbody burstBullet3; 
    [SerializeField] private float force;
    protected override void Attack(float percent)
    {
        print("my weapon attacked" + percent); 
        Ray camRay = InputManager.GetCameraRay(); 
        Rigidbody rb = Instantiate(burstBullet, camRay.origin, transform.rotation);
        Rigidbody rb2 = Instantiate(burstBullet2, camRay.origin, transform.rotation);
        Rigidbody rb3 = Instantiate(burstBullet3, camRay.origin, transform.rotation); 
        
        rb.AddForce(Mathf.Max(percent, 0.5f) * force * camRay.direction , ForceMode.Impulse);
        rb2.AddForce(Mathf.Max(percent, 0.7f) * force * camRay.direction , ForceMode.Impulse);
        rb3.AddForce(Mathf.Max(percent, 0.5f) * force * camRay.direction , ForceMode.Impulse); 
        
        Physics.IgnoreLayerCollision(1,2,true); 
        Physics.IgnoreLayerCollision(2,3,true); 
        Physics.IgnoreLayerCollision(1,3,true); 
        
        Destroy(rb.gameObject, 3);
        
    }
}
