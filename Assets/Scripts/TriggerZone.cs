using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private UnityEvent onZoneEnter;
    [SerializeField] private UnityEvent onZoneExit;

    private void OnTriggerEnter(Collider other)
    {
        onZoneEnter?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        onZoneExit?.Invoke();
    }

    private void Start()
    {
        onZoneEnter.AddListener(() => Debug.Log("Player entered trigger zone"));
        onZoneExit.AddListener(() => Debug.Log("Player left trigger zone"));
    }
}
