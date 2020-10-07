using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    // Start is called before the first frame update
    VerticalForse player;
    private AudioSource Sound;
    [SerializeField]
    private AudioClip[] Sounds = new AudioClip[4];
    [SerializeField]
    private float JumpForse;
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
            if (!player.IsJumping())
            {
                player.StartJump(JumpForse);
                Sound.Play();
            }
        }
    }

}
