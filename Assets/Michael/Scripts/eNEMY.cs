
using UnityEngine;

public class eNEMY : MonoBehaviour {

	public float health =50f;
	public AudioSource enemyDeath;
	public AudioClip deathsound;

	public void TakeDamage(float amount)
	{
		health -= amount;
		if (health <= 0f) 
		{
			Die ();
		}

	}

	public void Die()
	{
		GameObject me = transform.parent.gameObject;
		enemyDeath.Play ();
		Destroy (me);
	}
	
}
