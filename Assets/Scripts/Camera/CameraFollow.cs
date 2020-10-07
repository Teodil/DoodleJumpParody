using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.GetComponent<PlayerControler>().IsDead)
        {
            if (transform.position.y < Player.transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, Player.transform.position.y, transform.position.z);
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, Player.transform.position.y, transform.position.z);
        }
    }
}
