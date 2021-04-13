using UnityEngine;
using BzKovSoft.ObjectSlicerSamples;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BzKnife blade))
        {
            blade.GetComponentInParent<Slicer>().Stunning();
        }
    }
}
