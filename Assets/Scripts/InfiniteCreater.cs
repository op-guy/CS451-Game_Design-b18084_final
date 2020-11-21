using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteCreater : MonoBehaviour
{
    public GameObject[] obst; 
    public GameObject colorChanger;
    private GameObject tmpObject = null;
    private float bound;
    // private int i;
    void Start() 
    {
        bound = 0f;
        // i = 0;
    }
    
    void Update()
    {
        if(transform.position.y >= bound) 
        {
             
            
            if(tmpObject != null) {
                Destroy(tmpObject, 20);
            }

            
            int random_index = Random.Range(0,obst.Length);
            // if(i%2 == 0) random_index = 5;
            // else random_index = 4;
            // i++;

            if(System.Convert.ToInt32(Random.Range(0,2)) == 1) {
                // float offset = 0f;
                // if(random_index == 3 || random_index == 4) offset = 4f;  
                Instantiate(colorChanger, new Vector3(0, transform.position.y + 4f, 0), Quaternion.identity);
            }

            switch(random_index) {
                case 0:
                    bound = transform.position.y + 8f;
                    tmpObject = Instantiate(obst[random_index], new Vector3(0, transform.position.y + 8f, 0), Quaternion.identity);
                    break;
                case 1:
                    bound = transform.position.y + 10f;
                    tmpObject = Instantiate(obst[random_index], new Vector3(1.53f, transform.position.y + 8f, 0), Quaternion.identity);
                    break;
                case 2:
                    bound = transform.position.y + 8f;
                    tmpObject = Instantiate(obst[random_index], new Vector3(0.7335504f, transform.position.y + 8f, 0), Quaternion.identity);
                    break;
                case 3:
                    bound = transform.position.y + 10f;
                    tmpObject = Instantiate(obst[random_index], new Vector3(1.19f, transform.position.y + 8f, 0), Quaternion.identity);
                    break;
                case 4:
                    bound = transform.position.y + 8f;
                    tmpObject = Instantiate(obst[random_index], new Vector3(1.95f, transform.position.y + 4f, 0), Quaternion.identity);
                    break;
                case 5:
                    bound = transform.position.y + 14f;
                    tmpObject = Instantiate(obst[random_index], new Vector3(0.61f, transform.position.y + 8f, 0), Quaternion.identity);
                    break;
            }
        }
    }
}
