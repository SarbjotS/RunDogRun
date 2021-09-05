using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text score;
    public float scorePerSecond = 1f;
    public float scored = 0f;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        score.text = scored.ToString();
        scored += scorePerSecond * Time.deltaTime;
    }
}
