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
    /*void Update()
    {
        if (_IsJumping)
        {
            Jump();
        }
        else
        {
            Fall();
        }
    }*/
    public Vector3 GetVerticalForse()
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
    private Vector3 Jump()
    {
        //rigidbody.AddForce(new Vector2(0, JumpForse) * (TimerLimit - Timer));
        Timer += Time.deltaTime;
        if (Timer > TimerLimit)
        {
            Timer = 0;
            _IsJumping = false;
            return Fall();
        }
        //Debug.Log("Прыжок вектор " + new Vector3(0, FallForse, 0) * (TimerLimit - Timer));
        return new Vector3(0, JumpForse, 0) * (TimerLimit - Timer);
    }
    private Vector3 Fall()
    {
        Timer += Time.deltaTime;
        //rigidbody.AddForce(new Vector2(0, FallForse) * Timer);
        //Debug.Log("Падение вектор " + new Vector3(0, FallForse, 0));
        return new Vector3(0, FallForse, 0) * Timer; 
    }
    public void StartJump(float _JumpForse)
    {
        Timer = 0;
        _IsJumping = true;
        JumpForse = _JumpForse;
    }
    public bool IsJumping()
    {
        return _IsJumping;
    }
}
