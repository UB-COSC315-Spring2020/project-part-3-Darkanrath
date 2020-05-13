using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    bool isActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isActive == true)
            {
                StartCoroutine(DestroyThisAfterTime(0.25f));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isActive = false;
        }
    }

    IEnumerator DestroyThisAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        Destroy(this.gameObject);
    }
}
