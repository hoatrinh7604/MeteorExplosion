using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bangEffect;

    private bool startMoving;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startMoving)
        {
            //transform.position = new Vector3(transform.position.x + direction * speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Plane")
        {
            SoundController.Instance.PlayAudio(SoundController.Instance.bang, 0.5f, false);
            GamePlayController.Instance.UpdateSlider(5);
            BangEffect();
            Destroy(gameObject);
        }
    }

    public void StartMoving(int direc)
    {
        speed = UnityEngine.Random.Range(3, 5);
        direction = direc;
        startMoving = true;
    }

    public void BangEffect()
    {
        GameObject bang = Instantiate(bangEffect, Vector3.zero, Quaternion.identity);
        bang.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        bang.transform.localScale = Vector3.one;

        Destroy(bang, 3f);
    }

}
