using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidbody;
    [SerializeField]
    Vector2 StartPosition;
    [SerializeField]
    Vector2 TouchDelta;
    Touch touch;
    [SerializeField]
    float Speed = 50f;
    [SerializeField]
    float x;
    [SerializeField]
    Vector3 right;

    public bool IsDead = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        right = Vector2.right * Input.GetAxis("Horizontal") * 5;
        rigidbody.velocity = right;
#else
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                rigidbody.velocity = Vector3.zero;
                StartPosition = Camera.main.ScreenToWorldPoint(touch.position);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                /*TouchDelta = Camera.main.ScreenToWorldPoint(touch.position);
                x = TouchDelta.x - StartPosition.x;
                right = transform.right * x * Speed;
                rigidbody.velocity = right;
                StartPosition = TouchDelta;*/
                if (!IsDead)
                {
                    x = touch.deltaPosition.x;
                    right = transform.right * x * Speed;
                    rigidbody.velocity = right;
                }
            }
            else if( touch.phase == TouchPhase.Stationary)
            {
                rigidbody.velocity = right;

            }
            else if(touch.phase == TouchPhase.Ended)
            {
                //rigidbody.velocity = transform.right * new Vector2(0, rigidbody.velocity.y);
            }
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }
        //right = transform.right * Input.GetAxis("Horizontal") * 5;
#endif
    }
    public void Dead()
    {
        IsDead = true;
    }
}
