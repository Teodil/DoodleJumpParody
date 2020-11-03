using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private PlayerControler _player;
    void Start()
    {
        _player = (PlayerControler)FindObjectOfType(typeof(PlayerControler));
    }

    // Update is called once per frame
    void Update()
    {
        if (!_player.isDead)
        {
            if (transform.position.y < _player.transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, _player.transform.position.y, transform.position.z);
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, _player.transform.position.y, transform.position.z);
        }
    }
}
