using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour
{
    [SerializeField]
    private GameObject greenPipe, redPipe;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }
    bool isGreen;

    // Automatically generated at 1 point
    IEnumerator Spawner() {
        // Wait 1 second
        yield return new WaitForSeconds(2);
        Vector3 temp = greenPipe.transform.position;
        temp.y = Random.Range(-2.5f, 2.5f);
        if (isGreen)
        {
            Instantiate(greenPipe, temp, Quaternion.identity);
        }
        else
        {
            Instantiate(redPipe, temp, Quaternion.identity);
        }
        isGreen = !isGreen;

        StartCoroutine(Spawner());
    }
}
