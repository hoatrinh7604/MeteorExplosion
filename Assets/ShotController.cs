using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firingPos;
    [SerializeField] Transform targetPos;

    [SerializeField] float delayTime;
    [SerializeField] Animator anim;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        BackToIdle();
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shot();
        }
    }

    public void Shot()
    {
        if (time > delayTime)
        {
            SoundController.Instance.PlayAudio(SoundController.Instance.firing, 0.05f, false);
            anim.SetBool("Firing", true);

            GameObject obj = Instantiate(bullet, Vector3.zero, Quaternion.identity);
            obj.transform.position = firingPos.position;
            obj.transform.rotation = Quaternion.Euler(90 - (targetPos.position.y - firingPos.position.y), targetPos.position.x - firingPos.position.x, 0);
            obj.GetComponent<BulletController>().Firing(targetPos);

            Destroy(obj, 5f);
            time = 0;
        }
    }

    public void BackToIdle()
    {
        if(time > 0.1f && anim.GetBool("Firing"))
        {
            anim.SetBool("Firing", false);
        }
    }
}
