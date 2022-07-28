using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] GameObject bangEffect;
    private bool startFiring;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startFiring)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if(Vector3.Distance(transform.position, target) < 0.01f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Firing(Transform targetPos)
    {
        target = new Vector3(targetPos.position.x, targetPos.position.y, targetPos.position.z);
        startFiring = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            SoundController.Instance.PlayAudio(SoundController.Instance.bang, 0.3f, false);
            BangEffect(1);
            GamePlayController.Instance.UpdateScore(1);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Plane")
        {
            BangEffect(0.3f);
        }
    }

    public void BangEffect(float size)
    {
        GameObject bang = Instantiate(bangEffect, Vector3.zero, Quaternion.identity);
        bang.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        bang.transform.localScale = new Vector3(size, size, size);

        Destroy(bang, 3f);
    }
}
