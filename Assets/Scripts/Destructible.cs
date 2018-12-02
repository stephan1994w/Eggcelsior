// --------------------------------------
// This script is totally optional. It is an example of how you can use the
// destructible versions of the objects as demonstrated in my tutorial.
// Watch the tutorial over at http://youtube.com/brackeys/.
// --------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

	public GameObject destroyedVersion;	// Reference to the shattered version of the object

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
    void ResetDestructable()
    {
        Destroy(destroyedVersion);
        gameObject.SetActive(true);
    }
}
