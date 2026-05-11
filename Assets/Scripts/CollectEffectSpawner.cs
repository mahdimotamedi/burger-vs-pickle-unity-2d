using UnityEngine;

public class CollectEffectSpawner : MonoBehaviour
{
    public GameObject collectEffectPrefab;

    public void SpawnEffect(Vector3 position)
    {
        Instantiate(collectEffectPrefab, position, Quaternion.identity);
    }
}
