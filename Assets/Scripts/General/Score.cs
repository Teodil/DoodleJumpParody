using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Vector3 StartPoint;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    int score;
    void Start()
    {
        StartPoint = transform.parent.position;
    }
    private void Update()
    {
        if (transform.parent.hasChanged)
        {
            score = Convert.ToInt32(StartPoint.y - transform.parent.position.y) * -1;
            scoreText.text = score.ToString();
        }
    }
}
