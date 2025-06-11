using KBCore.Refs;
using UnityEngine;

namespace Player
{
  public class GroundChecker : ValidatedMonoBehaviour
  {
    [SerializeField] private float castRadius = 0.5f;
    [SerializeField] LayerMask groundLayers;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
      IsGrounded = Physics.SphereCast(transform.position + Vector3.up *
          (castRadius + Physics.defaultContactOffset), castRadius - Physics.defaultContactOffset, Vector3.down,
          out _, castRadius, groundLayers);
    }

    private void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.green;
      Gizmos.DrawWireSphere(transform.position + Vector3.up * castRadius + Vector3.down * castRadius,
          castRadius);
    }
  }
}