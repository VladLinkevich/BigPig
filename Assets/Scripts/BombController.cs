using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] private float destroyTime = 5f;

    void Start()
    {
        StartCoroutine(DestroyBomb());
    }

    private IEnumerator DestroyBomb()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
