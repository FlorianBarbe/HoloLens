using MixedReality.Toolkit.SpatialManipulation;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Ingredient : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField, Range(0.4f, 0.95f)] private float selectThreshold = 0.65f;
    [SerializeField, Range(0.05f, 0.5f)] private float deselectThreshold = 0.2f;
    [SerializeField, Range(1f, 1.5f)] private float colliderScale = 1.1f;

    private void Awake()
    {
        ConfigureGrab();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Four"))
        {
            gameManager.AddIngredient();
            gameObject.SetActive(false);
        }
    }

    private void ConfigureGrab()
    {
        if (TryGetComponent(out Rigidbody body))
        {
            body.useGravity = false;
            body.isKinematic = true;
            body.interpolation = RigidbodyInterpolation.Interpolate;
            body.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        }

        if (TryGetComponent(out ObjectManipulator manipulator))
        {
            manipulator.AllowedManipulations = (TransformFlags)1;
            manipulator.AllowedInteractionTypes = InteractionFlags.Near | InteractionFlags.Ray;
            manipulator.SelectThreshold = selectThreshold;
            manipulator.DeselectThreshold = deselectThreshold;
            manipulator.ReleaseBehavior = ObjectManipulator.ReleaseBehaviorType.None;
            manipulator.ApplyTorque = false;
            manipulator.RigidbodyMovementType = XRBaseInteractable.MovementType.Instantaneous;
            manipulator.SpringForceSoftness = 0.03f;
            manipulator.SpringTorqueSoftness = 0.03f;
            manipulator.SpringDamping = 1.5f;
            manipulator.SpringForceLimit = 1000f;
        }

        if (colliderScale > 1f && TryGetComponent(out BoxCollider boxCollider))
        {
            boxCollider.size *= colliderScale;
        }
    }
}
