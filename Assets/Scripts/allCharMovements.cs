using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class allCharMovements : MonoBehaviour
{    
    public float speed = 5, health = 100f;
    public int attackPower = 10;
    Vector3 poz;
    allCharMovements enemy;  
    public Transform TargetforRed, TargetforBlue;
    public bool blueT, redT,attack=false,die=false;
    public float attackSpeed=2;
    float attackTime=0;
    GameObject enemyOfDead;
    public GameObject retry;

    void Awake()
    {
        TargetforRed = GameObject.Find("leftBase").transform;
        TargetforBlue = GameObject.Find("rightBase").transform;
        Time.timeScale = 1;
    }
    void Start()
    {
        if (gameObject.tag == "blueTeam")
        {
            blueT = true;
        }
        if (gameObject.tag == "redTeam")
        {
            redT = true;
        }
        retry = GameObject.Find("retry");


    }

    // Update is called once per frame
    void Update()
    {
        if (blueT)
        {
            poz = new Vector3(TargetforBlue.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, TargetforBlue.position, speed * Time.deltaTime);
            if(transform.position==TargetforBlue.position)
            {
                Time.timeScale = 0;
                retry.GetComponent<Image>().enabled = true;
                retry.GetComponentInChildren<Text>().enabled = true;
            }
            
        }
        if (redT)
        {
            poz = new Vector3(TargetforRed.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, TargetforRed.position, speed * Time.deltaTime);
            if (transform.position == TargetforRed.position)
            {
                Time.timeScale = 0;
                retry.GetComponent<Image>().enabled = true;
                retry.GetComponentInChildren<Text>().enabled = true;
            }

        }                            

    }
    void OnTriggerEnter(Collider other)
    {
        enemy = other.GetComponent<allCharMovements>();
        enemyOfDead = other.gameObject;

        if (other.tag == gameObject.tag)
        {            
            speed = 0;
            attack = false;                       
        }
        else if (other.tag != gameObject.tag)
        {           
            speed = 0;
            
            if (gameObject.name == "redFire" && other.name == "blueEarth" || gameObject.name == "blueFire" && other.name == "redEarth")
            {
                Destroy(enemyOfDead);                
                speed = 5;

            }
            else if (gameObject.name == "redWater" && other.name == "blueFire" || gameObject.name == "blueWater" && other.name == "redFire")
            {
                Destroy(enemyOfDead);               
                speed = 5;

            }
            else if (gameObject.name == "redEarth" && other.name == "blueWater" || gameObject.name == "blueEarth" && other.name == "redWater")
            {
                Destroy(enemyOfDead);               
                speed = 5;

            }
            else
            {               
                Destroy(gameObject);
            }
                      
        }
        
        

    }
    
    

}
