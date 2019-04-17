using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 球类对应表（分值）：
 * 白球 -1
 * 无球 0
 * 红球 1
 * 黄球 2
 * 绿球 3
 * 棕球 4
 * 蓝球 5
 * 粉球 6
 * 黑球 7
 * 所有彩球 8
 */

public class GameManager : MonoBehaviour
{

    // public 

    public static GameManager instance = null;
    public Camera mainCamera;
    public GameObject whiteBall;
    public GameObject stick;
    public GameObject origin;

    public Vector3[] ColorBallPos;
    public GameObject[] RedBall;
    public GameObject[] ColorBall;
    public Text countText;
    public Text Info;
    public int count;       //总分
    public int score;       //单次得分

    public bool isHit;

    public bool isInHole;
    public bool isOrigin;      //是否在放置母球阶段
    public bool isFirst;       //是否改击打活球
    private Vector3 StickToBall;
    private float force;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        InitGame();
    }

    // Use this for initialization
    void Start()
    {
        isHit = false;
        isInHole = false;
        isOrigin = true;
        isFirst = true;
        count = 0;
        StickToBall = new Vector3(0, 0, 0);
        force = 0;
        CountShow();
    }

    // Update is called once per frame
    void Update()
    {
        Origin();
        Hit();
        CountUpDate();


    }

    void InitGame()
    {
        RedBall = GameObject.FindGameObjectsWithTag("RedBall");
        ColorBall = new GameObject[6];
        ColorBallPos = new Vector3[6];
        ColorBall[0] = GameObject.FindGameObjectWithTag("YellowBall");
        ColorBall[1] = GameObject.FindGameObjectWithTag("GreenBall");
        ColorBall[2] = GameObject.FindGameObjectWithTag("BrownBall");
        ColorBall[3] = GameObject.FindGameObjectWithTag("BlueBall");
        ColorBall[4] = GameObject.FindGameObjectWithTag("PinkBall");
        ColorBall[5] = GameObject.FindGameObjectWithTag("BlackBall");
        for (int i = 0; i < ColorBallPos.Length; i++)
        {
            ColorBallPos[i] = ColorBall[i].transform.position;
        }
    }

    void Turn()
    {

    }

    void Origin()
    {
        if (isOrigin)
        {
            whiteBall.SetActive(true);
            whiteBall.layer = 9;
            whiteBall.transform.position = GetTablePoint();

            if (origin.GetComponent<Origin>().isInD)
            {
                Info.text = "IN";
                if (Input.GetMouseButtonDown(0))
                {
                    isOrigin = false;
                    whiteBall.layer = 0;
                    isHit = true;
                }
            }
            else
            {
                Info.text = "OUT";
            }



        }
    }

    void Hit()
    {
        if (isHit)
        {
            if (whiteBall.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                stick.SetActive(true);
            }
            else
            {
                stick.SetActive(false);
            }
            StickToBall = whiteBall.transform.position - GetTablePoint();
            stick.transform.position = whiteBall.transform.position - 1.1f * StickToBall.normalized;
            stick.transform.LookAt(whiteBall.transform);
            stick.transform.Rotate(90, 0, 0);
            if (Input.GetMouseButtonDown(0) && stick.activeInHierarchy) //
            {
                stick.SetActive(false);
                whiteBall.GetComponent<Rigidbody>().AddForce(500 * StickToBall.normalized);

            }
        }

    }

    void CountUpDate()
    {
        if (isInHole)
        {
              
            if (CheckWhichBallToHit(isFirst) == 8 && score != 1)  //如果打二杆彩球
            {
                isFirst = !isFirst;
                CountAdd(score);
                CountShow();
                ResetPos(score);
            }
            else if (CheckWhichBallToHit(isFirst) == score)  //如果打活球
            {

               isFirst = !isFirst;
                CountAdd(score);
                CountShow();
            }
            else
            {
                if(score != 1)
                {
                    ResetPos(score);
                }
                Info.text = "WRONG";
            }
            isInHole = false;
            score = 0;
        }
    }
    void CountShow()
    {
        countText.text = "Count :" + count.ToString();



    }
    void ResetPos(int score)
    {
        ColorBall[score - 2].transform.position = ColorBallPos[score - 2];
        ColorBall[score - 2].SetActive(true);
    }

    void CountAdd(int score)
    {
        count += score;
    }
    int CheckWhichBallToHit(bool isFirst)
    {
        //如果是活球
        if (isFirst)
        {
            int lest = 0;
            for (int i = 0; i < RedBall.Length; i++)
            {
                if (RedBall[i].activeInHierarchy)
                {
                    lest++;
                }
            }
            
            if (lest > 0)    //击打红球
            {
                return 1;  //返回红球分数
            }
            else           //击打彩球
            {
                for (int i = 0; i < ColorBall.Length; i++)
                {
                    if (ColorBall[i].activeInHierarchy)
                    {
                        
                        return (i + 1);  //返回彩球分数  击打时已禁用
                    }
                }
                return 0;   //所有的球都清空
            }
        }
        else //如果不是
        {
            return 8; //可以打所有彩球
        }

    }

    //获取鼠标点位
    Vector3 GetTablePoint()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);//从摄像机发出到点击坐标的射线
        RaycastHit hitInfo;
        Physics.Raycast(ray, out hitInfo);
        Vector3 tablePos = new Vector3(hitInfo.point.x, 0.05f, hitInfo.point.z);
        return tablePos;
    }
}
