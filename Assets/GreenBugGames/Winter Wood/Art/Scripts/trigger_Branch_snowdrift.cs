using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_Branch_snowdrift : MonoBehaviour
{

    public GameObject goParticleSnow;
    public bool includeChildren = true;
	

    private void OnTriggerEnter(Collider col)
    {
        if ((col.tag == "Player"))
        {
            gameObject.AddComponent<Rigidbody>();
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * 10f);
            gameObject.GetComponent<Rigidbody>().mass = 150f;
            goParticleSnow.GetComponent<ParticleSystem>().Play(includeChildren);
            //Debug.Log("collaps "+ gameObject.name);
            StartCoroutine(DeleteSnowdrift());
        }
    }

    public IEnumerator DeleteSnowdrift()
    {
        yield return new WaitForSeconds(5);
		goParticleSnow.GetComponent<ParticleSystem>().Stop(includeChildren);
        Destroy(gameObject);
    }
}