// --------------------------------------
// This script is totally optional. It is an example of how you can use the
// destructible versions of the objects as demonstrated in my tutorial.
// Watch the tutorial over at http://youtube.com/brackeys/.
// --------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour {

    [SerializeField]
    private GameObject destroyedVersion;	// Reference to the shattered version of the object
    [SerializeField]
    private bool destoryGameObjects = false;

    protected void DestroyObject()
    {

        GameObject t = Instantiate(destroyedVersion, transform.position, transform.rotation);
      
        Rigidbody [] rbs = t.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rbs)
        {
            rb.velocity = gameObject.GetComponent<Rigidbody>().velocity/2;
        }

        if (destoryGameObjects)
        {
            Destroy(gameObject);
        } else
        {
            gameObject.SetActive(false);
        }

    }
    /* - Stephan do you need this?
    private void OnCollisionEnter(Collision collision)
    {




        if (collision.gameObject.CompareTag("Player"))
        {

            Instantiate(destroyedVersion, transform.position, transform.rotation);
            // Remove the current object
            gameObject.SetActive(false);
            Collider[] colChildren = destroyedVersion.GetComponentsInChildren<Collider>();

            foreach (Collider collider in colChildren)
            {
                collider.enabled = false;
            }

        }
    }
   // TODO TALK ABOUT DESTUCTION HANDLING
    public void ResetDestructable(GameObject gameObject)
    {
        Destroy(destroyedVersion);
        gameObject.SetActive(true);
    }

    public void RemoveDestructable(GameObject gameObject)
    {
        Destroy(destroyedVersion);
    }
     */
}
