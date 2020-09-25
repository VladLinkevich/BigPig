using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class PigStatus : MonoBehaviour
{
    public static PigStatus  pigStatus = null;
    [SerializeField] private GameObject pigPrefab;
    [SerializeField] private Vector3 startPos;
    private static GameObject _pig;

    public static Vector3 GetPosition
    {
        get { return _pig.transform.position; }
    }

    private void Awake()
    {
        if (pigStatus == null) { pigStatus = this; }
        else { Destroy(gameObject); }

        Initialize();
    }

    private void Initialize()
    {
        _pig = Instantiate(pigPrefab);
        _pig.transform.position = startPos;
    }
}
