using UnityEngine;

public class PunchDetection : MonoBehaviour
{
    public float punchThreshold = 1.5f;
    public LayerMask enemyLayer;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & enemyLayer) != 0)
        {
            float punchForce = rb.linearVelocity.magnitude;
            if (punchForce > punchThreshold)
            {
                var enemy = collision.gameObject.GetComponent<EnemyAITutorial>();
                if (enemy != null)
                {
                    enemy.TakeDamage(punchForce);
                }
            }
        }
    }
}
