using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    
    public GameObject Enemy;
    public GameObject Player;
    public GameObject bullet;
    public float speed;
    public Transform spawnPoint;
    [SerializeField] private float timer = 5;
    private float bulletTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, Player.transform.position, speed);
        ShootAtPlayer();
    }

    void ShootAtPlayer(){
        bulletTime -= Time.deltaTime;

        if(bulletTime>0){
            return;
        }
        bulletTime=timer;
        GameObject bulletObj = Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward*speed*10);
        Destroy(bulletObj);
    }

    
}
