using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenDarkener : MonoBehaviour
{
    public Image darkOverlay;
    public float transitionSpeed = 1f;
    private bool isDarkening = false;

    public void StartDarkening(Color targetColor)
    {
        darkOverlay.color = targetColor;
        darkOverlay.gameObject.SetActive(true);
        StartCoroutine(DarkenScreen());
    }

    private IEnumerator DarkenScreen()
    {
        isDarkening = true;
        Color targetColor = darkOverlay.color;
        targetColor.a = 1f; // Completamente opaco

        while (darkOverlay.color.a < 1f)
        {
            darkOverlay.color = Color.Lerp(darkOverlay.color, targetColor, transitionSpeed * Time.deltaTime);
            yield return null;
        }

        isDarkening = false;
    }
}
