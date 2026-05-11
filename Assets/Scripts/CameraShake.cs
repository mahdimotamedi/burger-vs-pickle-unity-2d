using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public float duration = 0.25f;
    public float strength = 0.15f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    public void Shake()
    {
        StopAllCoroutines();
        StartCoroutine(ShakeRoutine());
    }

    private IEnumerator ShakeRoutine()
    {
        float timer = 0f;

        while (timer < duration)
        {
            float x = Random.Range(-strength, strength);
            float y = Random.Range(-strength, strength);

            transform.position = startPosition + new Vector3(x, y, 0f);

            timer += Time.deltaTime;

            yield return null;
        }

        transform.position = startPosition;
    }
}
