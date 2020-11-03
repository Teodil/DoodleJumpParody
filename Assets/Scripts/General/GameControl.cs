using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent FinishMoving;
    [SerializeField]
    private AnimationCurve Easing;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartMoveCouratine(Transform WhoMove,Vector3 MoveTo, float TimeToMove)
    {
        StartCoroutine(MoveObjetToPosition(WhoMove,MoveTo, TimeToMove));
    }
    private IEnumerator MoveObjetToPosition(Transform WhoMove, Vector3 MoveTo, float TimeToMove)
    {
        if (WhoMove.gameObject.TryGetComponent(out Rigidbody2D rigidbody)) {
            rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        Vector3 startPosition = WhoMove.position;
        for(float i = 0; i < 1; i += Time.deltaTime / TimeToMove)
        {
            WhoMove.position = Vector3.LerpUnclamped(startPosition, MoveTo, Easing.Evaluate(i));
            yield return null;
        }
        if (WhoMove.gameObject.TryGetComponent(out Rigidbody2D rigidbody2))
        {
            rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        FinishMoving.Invoke();
        FinishMoving.RemoveAllListeners();
    }
}
