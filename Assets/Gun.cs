using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public float damage = 0f;
	public float range = 144f;


	public AudioClip shootsound;
	public Camera fpsCam;
	public GameObject impactEffect;
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
			eNEMY target = hit.transform.GetComponent<eNEMY>();
			if (target != null) 
			{
				target.TakeDamage(damage);
			}
			Instantiate (impactEffect, hit.point, Quaternion.LookRotation (hit.normal));
		}
	}

}
