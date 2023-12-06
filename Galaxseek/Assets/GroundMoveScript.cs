using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoveScript : MonoBehaviour
{

    public float moveSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
            {
            transform.position = transform.position + (Vector3.left * moveSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - (Vector3.left * moveSpeed);
        }



    }
}
