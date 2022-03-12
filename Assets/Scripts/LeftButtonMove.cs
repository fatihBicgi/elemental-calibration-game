using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButtonMove : MonoBehaviour
{
    int index = 0;
    public int totalLevels = 3;
    public float y0ofset = 180f;
    public Transform mainBase;
    public GameObject Fire, Water, Earth;
    public bool trainGolem;
    public float trainSpeed;
    float trainTime;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (index < totalLevels - 1)
            {
                index++;
                Vector2 position = transform.position;
                position.x += y0ofset;
                transform.position = position;
            }

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (index > 0)
            {
                index--;
                Vector2 position = transform.position;
                position.x -= y0ofset;
                transform.position = position;
            }

        }
        if (Input.GetKeyDown(KeyCode.W) && !trainGolem)
        {
            spawn();
            
        }
        if (trainGolem)
        {
            if (trainTime > trainSpeed)
            {
                trainTime = 0;
                trainGolem = false;
            }
            else
            {
                trainTime += Time.deltaTime;
            }
        }
    }
    public void spawn()
    {
        trainGolem = true;

        if (index == 0)
        {
            GameObject bullet = Instantiate(Fire, mainBase.position, mainBase.rotation);
            bullet.name = Fire.name;

        }
        if (index == 1)
        {
            GameObject bullet = Instantiate(Water, mainBase.position, mainBase.rotation);
            bullet.name = Water.name;
        }
        if (index == 2)
        {
            GameObject bullet = Instantiate(Earth, mainBase.position, mainBase.rotation);
            bullet.name = Earth.name;
        }

    }

}
