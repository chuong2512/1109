using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask CollisionMask;
    public GameObject Explosion;
    private float speed = 5f;
    private float rotateSpeed = 800;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("AudioManager2").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Time.deltaTime * speed + 0.01f, CollisionMask)) {
            Vector3 refectdir = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(refectdir.z, refectdir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);


}

        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) {
           Animator anim = other.gameObject.GetComponent<Animator>();
            anim.SetBool("die", true);
            audioSource.Play();
            other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            other.gameObject.tag = "Untagged";
            //  StartCoroutine(die(other.gameObject));
            GameManager.instance.ShootBtn.SetActive(false);
            GameObject firework = Instantiate(Explosion, other.gameObject.transform) as GameObject;
            firework.transform.SetParent(null);
           // Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    IEnumerator die(GameObject enemy) {
        yield return new WaitForSeconds(1f);
       

    }

}

