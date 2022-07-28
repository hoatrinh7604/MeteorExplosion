using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaw : MonoBehaviour
{
    [SerializeField] Transform spawPos;
    [SerializeField] int direction;
    [SerializeField] GameObject enemy;
    [SerializeField] float delayTime;
    [SerializeField] float delayTimeMin;
    [SerializeField] float delayTimeMax;

    private float time;
    private float timeGame;
    // Start is called before the first frame update
    void Start()
    {
        delayTime = Random.Range(delayTimeMin, delayTimeMax);
    }

    // Update is called once per frame
    void Update()
    {
        timeGame += Time.deltaTime;
        time += Time.deltaTime;

        //if(timeGame > 20)
        //{
        //    delayTime--;
        //    timeGame = 0;
        //    if (delayTime <= 0) delayTime = 0.7f;
        //}
        SpawEnemy();
    }

    public void InitEnemy()
    {
        GameObject obj = Instantiate(enemy, Vector3.zero, Quaternion.identity, spawPos);
        obj.transform.position = spawPos.position;
        obj.GetComponent<EnemyController>().StartMoving(direction);

        Destroy(obj, 15f);
    }

    public void SpawEnemy()
    {
        if(time > delayTime)
        {
            delayTime = Random.Range(delayTimeMin, delayTimeMax);
            InitEnemy();
            time = 0;
        }
    }
}
