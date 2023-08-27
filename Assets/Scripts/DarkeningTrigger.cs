using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DarkeningTrigger : MonoBehaviour
{
    public float effectDuration = 2f;
    public Color highlightColor = new Color(0f, 0f, 0f, 1f);
    public Image imageToChangeOpacity;
    public GameObject player;

    private Color originalColor;
    private bool isInside = false;

    private void Start()
    {
        originalColor = imageToChangeOpacity.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player && !isInside)
        {
            isInside = true;
            StartCoroutine(ChangeOpacityAndPause());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            isInside = false;
        }
    }

    private IEnumerator ChangeOpacityAndPause()
    {
        float elapsedTime = 0f;
        Color startColor = imageToChangeOpacity.color;
        float originalTimeScale = Time.timeScale;

        while (elapsedTime < effectDuration)
        {
            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp01(elapsedTime / effectDuration);
            Color newColor = Color.Lerp(startColor, highlightColor, t);
            imageToChangeOpacity.color = newColor;

            float pauseAmount = Mathf.Lerp(originalTimeScale, 0f, t); // Time.timeScale goes from original to 0 (paused)
            Time.timeScale = pauseAmount;

            yield return null;
        }

        // Restaurar el tiempo escalar y opacidad a sus valores originales
        Time.timeScale = originalTimeScale;
        imageToChangeOpacity.color = originalColor;

        // Aquí puedes realizar otras acciones después del efecto
    }
}
