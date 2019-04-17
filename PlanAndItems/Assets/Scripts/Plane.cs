using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plane : MonoBehaviour {

    public GameObject Gameover;
    public Text TimeLest;
    public Text Score;
    public Text HighestScore;

    public float AutoRotateSpeed = 1;
    public float ControlRotateSpeed = 1;
    public int score;
    public int highestScore;
    public float time;
    public float AutoRotatoTime;
    public float AutoRotatoTimeStandard = 2;
    Vector3 autoRotatoTo;

    public bool turn;

    // Use this for initialization
    void Start () {
        turn = true;
        Gameover.SetActive(false);
        highestScore = 0;
        score = 0;
        time = 60;
        AutoRotatoTime = 0;
        autoRotatoTo = Vector3.zero;
        HighestScore.text = "HighestScore:" + highestScore.ToString();
    }
	
	
	void FixedUpdate () {
        if(time > 0)
        {

            Score.text = "Score:" + score.ToString();
            //HighestScore.text = "HighestScore:" + highestScore.ToString();

            time -= Time.fixedDeltaTime;

            TimeLest.text = "Time:" + string.Format("{0:f2}", time);

        }
        
        if (time<=0)
        {
            Gameover.SetActive(true);         //Game Over
            if(score > highestScore && turn)
            {
                highestScore = score;
                HighestScore.text = "HighestScore:" + highestScore.ToString();
                turn = false;
            }
        }
	}
    // Update is called once per frame
    private void Update()
    {
        if(time > 0)
        {
            Shack();
            Control();

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Item"))
        {
            score += 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Item"))
        {
            score -= 1;
        }
    }

    private void Shack()
    {
        AutoRotatoTime -= Time.deltaTime;
        
        if (AutoRotatoTime <= 0)
        {
            autoRotatoTo = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            AutoRotatoTime = AutoRotatoTimeStandard;

        }
        this.transform.Rotate(AutoRotateSpeed * autoRotatoTo);

    }

    private void Control()
    {
        float rotatoZ = Input.GetAxis("Horizontal");
        float rotatoX = Input.GetAxis("Vertical");
        Vector3 rotatoTo = new Vector3(-rotatoX, 0.0f, rotatoZ);
        this.transform.Rotate(rotatoTo * ControlRotateSpeed);

    }
}
