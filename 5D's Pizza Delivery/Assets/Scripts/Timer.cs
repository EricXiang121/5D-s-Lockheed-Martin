using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI ButtonText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;  
    public int roundedTime;
    public Button yourButton;
    public bool addtime;
    public int addingTime;



    void Start()
    {

    }

    public void Update()
    {

        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        roundedTime = (int)currentTime + addingTime;
        if (addtime)
        {
            addingTime += 5;
            addtime = false;

        }
        if (roundedTime < 10)
        {
            TimerText.text = "0:0" + roundedTime.ToString();
        
        }    
        else if (roundedTime >= 10 && roundedTime < 60) 
        {
            TimerText.text = "0:" + roundedTime.ToString();
        }
        else if (roundedTime == 60)
        {
            TimerText.text = "1:00";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }



    }

    public void CorrectAnswer()
    {
        addtime = true;
    }

}