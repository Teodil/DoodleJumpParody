using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Border OtherSide;
    
    public bool Entered = false;

    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name + " коснулся " + this.name);
        if(collision.tag == "Player")
        {
            if (!Entered)
            {
                Vector3 transsion;
                transsion = new Vector3(transform.position.x * -1, collision.transform.position.y, collision.transform.position.z);
                Debug.Log(collision.name + "телепортировался в " + transsion.ToString());
                OtherSide.Entered = true;
                Entered = true;
                collision.transform.position = transsion;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Entered)
        {
            Vector3 transsion;
            Debug.Log(collision.name + " стоит в " + name);
            transsion = new Vector3(collision.transform.position.x - 0.1f * GetSign(transform.position.x), collision.transform.position.y, collision.transform.position.z);
            Debug.Log(collision.name + " перемещается в " + transsion.ToString());
            collision.transform.position = transsion;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.name + "вышел из" + this.name);
        Entered = false;
        if (OtherSide.Entered == false)
        {
            OtherSide.Entered = false;
        }
    }
    private float GetSign(float x)
    {
        if (x > 0)
        {
            return x / x;
        }
        else if (x < 0)
        {
            return x / x * -1;
        }
        else
        {
            return 0;
        }
    }
}
