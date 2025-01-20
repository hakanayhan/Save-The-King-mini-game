using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCollisionController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            GameManager.Instance.Win();
        }
    }
}
