using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightFlashEffect : MonoBehaviour
{
    [SerializeField] private Vector2 delayRange;
    [SerializeField, Tooltip("If there is a halo component, you can reference it here so it too blinks accordingly.")] private Behaviour halo;

    private Light lightComponent;
    private Coroutine flashLightCO;

    private void Awake()
    {
        lightComponent = GetComponent<Light>();
    }

    public void ToggleLight(bool enable)
    {
        if (enable) flashLightCO = StartCoroutine(FlashLightCO());
        else
        {
            StopCoroutine(flashLightCO);
            EnableLight(false);
        }
    }

    private void EnableLight(bool enable)
    {
        lightComponent.enabled = enable;
        if (halo) halo.enabled = enable;
    }

    private IEnumerator FlashLightCO()
    {
        while (true)
        {
            EnableLight(false);
            yield return new WaitForSeconds(Random.Range(delayRange.x, delayRange.y));

            EnableLight(true);
            yield return new WaitForSeconds(Random.Range(delayRange.x, delayRange.y));
        }
    }
}
