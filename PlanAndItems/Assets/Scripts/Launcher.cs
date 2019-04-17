using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{

    
    public GameObject[] items;

    public int perTime;
    public float width;
    public float length;

    private Transform m_transform;
    
    //public float timeVal;
    //public float timeStandard;
    // Use this for initialization
    void Start()
    {
        //width = 20;
        //length = 20;
        m_transform = this.transform;
       // timeVal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < perTime; i++)
        {
            Instantiate(RandomGo(),RandomPos(),RandomRo());
       }
    }

    //生成随机位置
    private Vector3 RandomPos()
    {

        return new Vector3(m_transform.position.x+Random.Range(-width/2,width/2),m_transform.position.y, m_transform.position.z + Random.Range(-length / 2, length / 2));
    }

    //选择随机物体
    private GameObject RandomGo()
    {
        return items[Random.Range(0, items.Length)];
    }

    //生成随机角度
    private Quaternion RandomRo()
    {
        return Quaternion.Euler(Random.Range(0.0f, 180f), Random.Range(0.0f, 180f), Random.Range(0.0f, 180f));
    }

}
