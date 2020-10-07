using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] Blocks = new GameObject[5];

    private Vector3 StartPosition;
    [SerializeField]
    private int SpawnBlockCount;

    private const float MinRangeLimit = 3;
    private const float MaxRangeLimit = 5;

    private float _IncreaseRange = 0.01f;


    [Range(1f, 3f)] public float MinVerticalDistanse;
    [Range(2f, 10f)] public float MaxVerticalDistanse;

    public bool check = false;
    public Animator animator;

    void Start()
    {
        StartPosition = GameObject.FindGameObjectWithTag("Start").transform.position;
        //Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (check == true)
        { 
            if (StartPosition.y - transform.parent.position.y < 5)
            {
                Respawn();
                IncreaseRange();
            }
        }
        else
        {
            if (animator.GetBool("Finished"))
            {
                check = true;
            }
        }
    }
    private void Respawn()
    {
        Vector3 LastPosition = new Vector3(0,0,0);
        for(int i=0;i< SpawnBlockCount; i++)
        {
            if (i == 0)
            {
                LastPosition = StartPosition;
            }
            Vector3 NewPosition = new Vector3(Random.Range(-2, 2), LastPosition.y + Random.Range(MinVerticalDistanse, MaxVerticalDistanse), LastPosition.z);
            Instantiate(Blocks[Random.Range(0, Blocks.Length - 1)], NewPosition, new Quaternion(0, 0, 0, 0));
            LastPosition = NewPosition;
        }
        StartPosition = LastPosition;
    }
    private void IncreaseRange()
    {
        MinVerticalDistanse += _IncreaseRange;
        MaxVerticalDistanse += _IncreaseRange;
        _IncreaseRange += 0.01f;
    }
}
