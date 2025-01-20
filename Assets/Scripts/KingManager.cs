using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingManager : MonoBehaviour
{
    private float contactTime = 0f;
    public float requiredTime = 5f;
    private int objectsInWater = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            objectsInWater++;

            if (objectsInWater == 1)
            {
                contactTime = 0f;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            objectsInWater--;

            if (objectsInWater <= 0)
            {
                objectsInWater = 0;
                contactTime = 0f;
            }
        }
    }

    void Update()
    {
        if (objectsInWater > 0)
        {
            contactTime += Time.deltaTime;

            if (contactTime >= requiredTime)
            {
                GameManager.Instance.Lose();
            }
        }
    }
}
