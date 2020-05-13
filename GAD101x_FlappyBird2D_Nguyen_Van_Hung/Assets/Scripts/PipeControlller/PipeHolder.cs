using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHolder : MonoBehaviour
{
    // Speed of movement
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BirdController.instance != null)
        {
            if (BirdController.instance.flag == 1)
            {
                Destroy(GetComponent<PipeHolder>());
            }
        }
        PipeMovement();
    }

    public void PipeMovement() {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }

    // Catch collision between PipeHolder and Destroy
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Destroy") {
            Destroy(gameObject);
        }
    }
}
