using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class TargetGameController : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float timeLeft = 30.0f;
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = ("Time to deadline: ") + timeLeft.ToString("0");
        if(timeLeft <= 0){
            Debug.Log("game lost");
            SceneManager.LoadScene("Level1");
        }
    }
    public void TargetDestroyed(int timeBonus){
        timeLeft += timeBonus;
        if(GameObject.FindObjectsOfType<DestroyableTarget>().Length==0){
            Debug.Log("Game Won");     
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);  
            if (SceneManager.GetActiveScene().buildIndex == 4){
                Cursor.lockState = CursorLockMode.None;
            }              
        }
    }
}
