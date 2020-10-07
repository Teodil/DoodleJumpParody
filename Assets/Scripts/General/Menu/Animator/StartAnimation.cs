using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StartAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject button;

     
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartPlay()
    {
        button.SetActive(false);
        animator.SetTrigger("Start");
    }
}
