using UnityEngine;
using UnityEngine.Events;

public class Conveyor : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _speed;

    public event UnityAction DestroyFood;

    private void OnTriggerStay(Collider other)
    {
        other.transform.position = Vector3.MoveTowards(other.transform.position, _endPoint.position, _speed * Time.deltaTime);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Food"))
            DestroyFood?.Invoke();

        Destroy(other.gameObject);
    }
}
