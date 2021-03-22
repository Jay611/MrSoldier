using UnityEngine;

/*	
	This component is for all objects that the player can
	interact with (items). It is meant to be used as a base class.
*/

public class Interactable : MonoBehaviour {

    //Some variables.
	public float radius = 3f;				// How close do we need to be to interact?
	public Transform interactionTransform;	// The transform from where we interact in case you want to offset it

	public Transform player;		// Reference to the player transform


	public virtual void Interact ()
	{

	}

	// Draw our radius in the editor
	void OnDrawGizmosSelected ()
	{
        //Draw the Gizmo on screen.
		if (interactionTransform == null)
        {
			interactionTransform = transform;
        }

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}

}
