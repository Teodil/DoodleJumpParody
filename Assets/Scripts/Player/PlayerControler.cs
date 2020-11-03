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
    float x;
    [SerializeField]
    float _Speed;
    [SerializeField]
    Vector3 right;
    [SerializeField]
    Vector3 up;
    [SerializeField]
    VerticalForse verticalForse;
    [SerializeField]
    public bool isDead {private set;  get; }
    [SerializeField]
    public bool gameStarted { private set ; get; }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        isDead = false;
        gameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameStarted)
        {
            right = Vector2.right * Input.GetAxis("Horizontal") * 5;
            rigidbody.velocity = right + verticalForse.GetVerticalForse();
            /*if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    StartPosition = Camera.main.ScreenToWorldPoint(touch.position);
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    if (!isDead)
                    {
                        x = touch.deltaPosition.x;
                        right = transform.right * x * _Speed;
                        rigidbody.velocity = right + verticalForse.GetVerticalForse();
                    }
                }
                else if (touch.phase == TouchPhase.Stationary)
                {
                    rigidbody.velocity = right + verticalForse.GetVerticalForse();

                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    //rigidbody.velocity = transform.right * new Vector2(0, rigidbody.velocity.y);
                    x = 0;
                }
            }
            else
            {
                right *= x;
                rigidbody.velocity = right + verticalForse.GetVerticalForse();
            }*/
        }
        else
        {
            rigidbody.velocity = verticalForse.GetVerticalForse();
        }
    }
    public void Dead()
    {
        isDead = true;
    }
    public void StartGame()
    {
        gameStarted = true;
    }
}
