using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    public bool CheckForLayerInside(Collider other, string layerName)
    {
        Collider[] collidersInside = Physics.OverlapBox(other.bounds.center, other.bounds.extents, Quaternion.identity);

        foreach (Collider collider in collidersInside)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer(layerName))
            {
                return true;
            }
        }

        return false;
    }
}
