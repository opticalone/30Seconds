
using UnityEngine;

public class _Player : MonoBehaviour {

	public float damage = 0f;
	public float range = 144f;
	[SerializeField]
	public Camera fpsCam;

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1")) {
		
			Shoot ();
		}
	}


	void Shoot ()
	{
		RaycastHit hit;

		if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit,range))
		{
			Debug.Log (hit.transform.name);
		}
	}


}