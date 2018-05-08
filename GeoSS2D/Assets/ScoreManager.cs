using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    int score = 0;
    TextMesh scoreText;
    TextMesh targetText;

	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find("TextScore").GetComponent("TextMesh") as TextMesh;
        targetText = GameObject.Find("TextNextTarget").GetComponent("TextMesh") as TextMesh;
        increaseScore(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void setNextTarget(int val){
        
    }
    public void increaseScore(int val){
        score += val;
        scoreText.text = "Score: "+score.ToString();
    }
    public void decreaseScore(int val)
    {
        score -= val;
    }
    void resetScore(){
        score = 0;
    }
}
