using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject gameObject;
    [SerializeField]
    Camera camera;

    public UnityEvent dead;

    void Start()
    {
        float y = transform.parent.position.y - camera.orthographicSize;
        transform.position = new Vector3(transform.parent.position.x, y, transform.parent.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Дестроер коснулся " + collision.gameObject.name);
        if (collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);

        }
        else
        {
            dead.Invoke();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Дестроер коснулся " + collision.gameObject.name);
        Destroy(collision.gameObject);
    }
}
