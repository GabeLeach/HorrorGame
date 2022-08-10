using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableTarget : MonoBehaviour
{
    public int timeBonus = 10;
    TargetGameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null){
            gameController = gameControllerObject.GetComponent<TargetGameController>();
        }
        if(gameController == null){
            Debug.Log("Cannot find TargetGameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision){
        DestroyObject(gameObject);
    }
    private void OnDestroy(){
        if(gameController !=null){
        gameController.TargetDestroyed(timeBonus);
        }
    }
}
