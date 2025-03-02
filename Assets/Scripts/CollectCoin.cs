using System;
using TMPro;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public static event Action isCollected;
    public static float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f,Time.time*100f,0);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            isCollected?.Invoke();
            Destroy(gameObject);
            IncreaseScore();
        }
    }

    private void IncreaseScore()
    {
        score++;
        scoreText.text = $"Coins Collected: {score}";
    }
}

