using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalForse : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidbody;
    [SerializeField]
    private bool _IsJumping = false;
    [SerializeField]
    private float JumpForse;
    [SerializeField]
    private float FallForse;
    [SerializeField]
    private float Timer;
    [SerializeField]
    private float TimerLimit;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_IsJumping)
        {
            Jump();
        }
        else
        {
            Fall();
        }
    }
    public Vector2 VeticalForse()
    {
        if (_IsJumping)
        {
           return Jump();
        }
        else
        {
            return Fall();
        }
    }
    private Vector2 Jump()
    {
        Timer += Time.deltaTime;
        if (Timer > TimerLimit)
        {
            Timer = 0;
            _IsJumping = false;
        }
        return new Vector2(0, JumpForse) * (TimerLimit - Timer);
    }
    private Vector2 Fall()
    {
        Timer += Time.deltaTime;
        return new Vector2(0, FallForse) * Timer;
    }
    public void StartJump(float _JumpForse)
    {
        Timer = 0;
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
        _IsJumping = true;
        JumpForse = _JumpForse;
    }
    public bool IsJumping()
    {
        return _IsJumping;
    }
}
