using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover_camara : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
 
    // Update is called once per frame
    void Update()
    {
        //va ser que siga al jugador la camara
        if (playerTransform.position.y > transform.position.y)
        {

            transform.position = new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);

        }
    }
}
