using UnityEngine;
using UnityEngine.UI;

public class ConfettiTrigger : MonoBehaviour
{
    public Button confettiButton;
    public ParticleSystem confettiEffect;
    public AudioSource confettiSound;  // 🔹 Make sure this is PUBLIC

    void Start()
    {
        confettiSound = GetComponent<AudioSource>();

        if (confettiButton != null)
        {
            confettiButton.onClick.AddListener(PlayConfetti);
        }
        else
        {
            Debug.LogError("Confetti Button is NOT assigned!");
        }

        if (confettiSound == null)
        {
            Debug.LogError("Confetti Sound is NOT assigned in the Inspector!");
        }
    }

    public void PlayConfetti()
    {
        Debug.Log("Button Clicked! Playing Confetti & Sound...");

        if (confettiEffect != null)
        {
            confettiEffect.Play();
            Debug.Log("Confetti played!");
        }
        else
        {
            Debug.LogError("Confetti Particle System is NOT assigned!");
        }

        if (confettiSound != null)
        {
            confettiSound.Play();
            Debug.Log("Sound played!");
        }
        else
        {
            Debug.LogError("Confetti Sound is NOT assigned!");
        }
    }
}
