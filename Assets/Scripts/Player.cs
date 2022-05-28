using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] TMP_Text puntajeText;
    [SerializeField] RawImage hearts;
    [SerializeField] GameObject titleObj;
    [SerializeField] GameObject origin;
    int score = 0;
    public int life = 3;
    AudioSource playerAudioSource;
    [SerializeField] AudioClip getHit;

    private globalSense global;

    private void Awake()
    {
        global = GameObject.FindGameObjectWithTag("global").GetComponent<globalSense>();
        playerAudioSource = this.GetComponent<AudioSource>();
    }

    public void updateHearts()
    {
        life--;
        playerAudioSource.PlayOneShot(getHit);
        switch(life)
        {
            case 3: 
                    hearts.rectTransform.sizeDelta = new Vector2(0.06f, 0.02f);
                    hearts.uvRect.Set(0f, 0f, 3f, 1f);
                break;
            case 2:
                    hearts.rectTransform.sizeDelta = new Vector2(0.04f, 0.02f);
                    hearts.uvRect.Set(0f, 0f, 2f, 1f);
                break;
            case 1:
                    hearts.rectTransform.sizeDelta = new Vector2(0.02f, 0.02f);
                    hearts.uvRect.Set(0f, 0f, 1f, 1f);
                break;
            case 0:
                resetGame();
                break;
        }
    }

    void resetGame()
    {
        global.gameState = false;
        titleObj.SetActive(true);
        origin.SetActive(false);
        puntajeText.text = "Best: " + score;
        score = 0;
    }

    public void updatePuntaje()
    {
        score++;
        puntajeText.text = "Kills: " + score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Killer"))
        {
            updateHearts();
        }
    }
}
