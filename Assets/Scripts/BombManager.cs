using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab = null;
    
    private GameObject _bomb;
    private const float OFFSET = 1f;
    private void Awake()
    {
        Messenger<Vector3>.AddListener(GameEvent.PLANTINGBOMB, PlantingBomb);
    }

    private void OnDestroy()
    { 
        Messenger<Vector3>.RemoveListener(GameEvent.PLANTINGBOMB, PlantingBomb);
    }

    private void PlantingBomb(Vector3 position)
    {
        _bomb = Instantiate(bombPrefab);
        _bomb.transform.position = GetPositionPlanting(position);
     }

    private Vector3 GetPositionPlanting(Vector2 pos)
    {
        Vector2 result = Vector2.zero;
        float boxSize = 1.1f;
        int collisionAmount = 0;
        do
        {
            collisionAmount = 0;
            boxSize -= 0.1f;
            result = Vector2.zero;
            Collider2D[] rays = Physics2D.OverlapBoxAll(pos, new Vector2(boxSize, boxSize), 0f);
            foreach (Collider2D ray in rays)
            {
                if (ray.isTrigger)
                {
                    result += new Vector2(ray.transform.position.x, ray.transform.position.y);
                    ++collisionAmount;
                }
            }

        } while (collisionAmount % 2 != 0);
         
        
        return new Vector3(result.x / collisionAmount, result.y / collisionAmount, result.y / collisionAmount);
    }
}
