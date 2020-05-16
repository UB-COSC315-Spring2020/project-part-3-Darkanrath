using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    // Is this object the active object targetted by the player?
    bool isActive = false;

    private void Update()
    {
        // If E is pressed, and the object is active, start destruction Coroutine
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isActive == true)
            {
                StartCoroutine(DestroyThisAfterTime(0.25f));
            }
        }
    }

    // Checks colliders to see if Player is at this object
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isActive = true;
        }
    }

    // Object is no longer active once player leaves the collider
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isActive = false;
        }
    }

    // Destroys object after X time
    IEnumerator DestroyThisAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        Destroy(this.gameObject);
    }
}
