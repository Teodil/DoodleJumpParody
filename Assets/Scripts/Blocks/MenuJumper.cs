using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuJumper : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Настройка блока")]
    VerticalForse player;
    private AudioSource Sound;
    [SerializeField]
    private AudioClip[] Sounds = new AudioClip[4];
    [SerializeField]
    private float JumpForse;

    [SerializeField]
    private StartEvent _StartEvent;
    [SerializeField]
    private bool IsGameStarted = false;

    [Header("Настройка перемещения")]
    [SerializeField]
    private Transform _PlayerTransform;
    [SerializeField]
    private Transform MoveToPosition;
    [SerializeField]
    private float time;


    void Start()
    {
        Sound = GetComponent<AudioSource>();
        Sound.clip = Sounds[Random.Range(0, Sounds.Length - 1)];
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject.GetComponent<VerticalForse>();
            if (!IsGameStarted)
            {
                UsualJump();
            }
            else
            {
                StartGameJump();
            }
        }
    }
    private void UsualJump()
    {
        if (!player.IsJumping())
        {
            player.StartJump(JumpForse);
            Sound.Play();
        }
    }
    private void StartGameJump()
    {
        _StartEvent.Invoke(_PlayerTransform, MoveToPosition.position + new Vector3(0, 0.2f, 0), time);
        Sound.Play();

    }
    public void StartGame()
    {
        IsGameStarted = true;
    }

}

[System.Serializable]
public class StartEvent : UnityEvent<Transform, Vector3, float>
{

}
