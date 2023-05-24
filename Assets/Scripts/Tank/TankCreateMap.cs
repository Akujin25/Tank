using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCreateMap : MonoBehaviour
{
    public GameObject tree;
    public GameObject Block;
    public GameObject Rock;
    float x;
    float y;
    float createTime = 0.3f;

    // Update is called once per frame
    void Update()
    {
        if (createTime < 1)
        {
            createTime += Time.deltaTime;
        }
        
        if ( Input.GetKey(KeyCode.T) && (createTime > 0.3))
        {
            createTime = 0;
            x = (float)((int)(transform.position.x / 0.32) * 0.32);
            Debug.Log(transform.position.x);
            Debug.Log(transform.position.x / 0.32);
            Debug.Log(x);
            y = (float)((int)(transform.position.y / 0.32) * 0.32);
            Instantiate(tree, new Vector3(x,y,0), Quaternion.identity);
        }

        if (Input.GetKey(KeyCode.R) && (createTime > 0.3))
        {
            createTime = 0;
            x = (float)((int)(transform.position.x / 0.32) * 0.32);
            Debug.Log(transform.position.x);
            Debug.Log(transform.position.x / 0.32);
            Debug.Log(x);
            y = (float)((int)(transform.position.y / 0.32) * 0.32);
            Instantiate(Rock, new Vector3(x, y, 0), Quaternion.identity);
        }

        if (Input.GetKey(KeyCode.B) && (createTime > 0.3))
        {
            createTime = 0;
            x = (float)((int)(transform.position.x / 0.32) * 0.32);
            Debug.Log(transform.position.x);
            Debug.Log(transform.position.x / 0.32);
            Debug.Log(x);
            y = (float)((int)(transform.position.y / 0.32) * 0.32);
            Instantiate(Block, new Vector3(x, y, 0), Quaternion.identity);
        }
    }
}
