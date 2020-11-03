using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreResult : MonoBehaviour
{
    // Start is called before the first frame updatet
    [SerializeField]
    private Text resultText;
    [SerializeField]
    private Text score;

    private void Awake()
    {
        resultText = GetComponent<Text>();
        resultText.text = "Your scor: " + score.text;
    }
}
