using UnityEngine;
using UnityEngine.UI;  // Required for UI interactions

public class ConfettiTrigger : MonoBehaviour
{
    public Button confettiButton;  // Assign the button in the Inspector
    public ParticleSystem confettiEffect;  // Assign the Particle System in the Inspector

    void Start()
    {
        Debug.Log("ConfettiTrigger script is running!"); // Confirm script is running

        if (confettiButton != null)
        {
            confettiButton.onClick.AddListener(PlayConfetti);
            Debug.Log("Confetti Button is assigned and listening for clicks!"); // Confirm button is assigned
        }
        else
        {
            Debug.LogError("Confetti Button is NOT assigned in the Inspector!");
        }
    }

    public void PlayConfetti()
    {
        Debug.Log("Button Clicked! Calling PlayConfetti()...");

        if (confettiEffect != null)
        {
            confettiEffect.Play();
            Debug.Log("Confetti played successfully!");
        }
        else
        {
            Debug.LogError("Confetti Particle System is NOT assigned in the Inspector!");
        }
    }
}
