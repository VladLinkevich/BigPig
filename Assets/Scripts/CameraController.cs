using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer backgroundSprite;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.2f;

    private Vector3 _velocity = Vector3.zero;
    private float _widthBack;
    private Camera _camera;

    private void Start()
    {
        _widthBack = backgroundSprite.size.x * backgroundSprite.transform.localScale.x;
        _camera = GetComponent<Camera>();
    }
    private void LateUpdate()
    {

        if ((_widthBack / 2) - 10 > Mathf.Abs(target.transform.position.x))
        {
            Vector3 targetPosition = new Vector3(
                target.position.x, 0, -10);

            transform.position = Vector3.SmoothDamp(transform.position,
                targetPosition, ref _velocity, smoothTime);
        }

    }


}
