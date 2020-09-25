using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigController : MonoBehaviour
{
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float offsetXInDegrees = 15;
    private Rigidbody2D _body;

    #region work with listener
    private void Awake()
    {
        Messenger.AddListener(GameEvent.DOWNMOVE, MoveToTheDown);
        Messenger.AddListener(GameEvent.LEFTMOVE, MoveToTheLeft);
        Messenger.AddListener(GameEvent.RIGHTMOVE, MoveToTheRight);
        Messenger.AddListener(GameEvent.UPMOVE, MoveToTheUp);
        Messenger.AddListener(GameEvent.REGUESTFORPLANTING, RequestForPlant);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.DOWNMOVE, MoveToTheDown);
        Messenger.RemoveListener(GameEvent.LEFTMOVE, MoveToTheLeft);
        Messenger.RemoveListener(GameEvent.RIGHTMOVE, MoveToTheRight);
        Messenger.RemoveListener(GameEvent.UPMOVE, MoveToTheUp);
        Messenger.RemoveListener(GameEvent.REGUESTFORPLANTING, RequestForPlant);
    }
    #endregion 

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _body.velocity = new Vector2(0, 0);

        transform.position = new Vector3(transform.position.x,
            transform.position.y,
            transform.position.y);
    }

    private void RequestForPlant()
    {
        Messenger<Vector3>.Broadcast(GameEvent.PLANTINGBOMB, transform.position);
    }

    #region move
    private void MoveToTheDown()
    {
        _body.velocity = new Vector2(-CalculateOffsetX(offsetXInDegrees), -speed);
    }
    private void MoveToTheUp()
    {
        _body.velocity = new Vector2(CalculateOffsetX(offsetXInDegrees), speed);
    }
    private void MoveToTheRight()
    {
        _body.velocity = new Vector2(speed, 0);
    }
    private void MoveToTheLeft()
    {
        _body.velocity = new Vector2(-speed, 0);
    }

    private float CalculateOffsetX(float degrees)
    {
        return Mathf.Sin(degrees * Mathf.Deg2Rad) * speed;
    }

    #endregion move
}
