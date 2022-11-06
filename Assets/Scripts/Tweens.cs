using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweens : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField, Range(0, 1)] private float normalizedTime;
    [SerializeField] private float duration = 5;
    [SerializeField] private Color initialColor;
    [SerializeField] private Color finalColor;
    [SerializeField] private AnimationCurve curve;

    private float currentTime = 0f;
    private Vector3 initialPosition;
    private Vector3 finalPosition;
    private SpriteRenderer spriteRenderer;



    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
      
    }
    void start()
    {
          StartTween();
    }

    private void Update()
    {
        normalizedTime = currentTime / duration;
        transform.position = Vector3.Lerp(initialPosition, finalPosition, curve.Evaluate(normalizedTime));
        spriteRenderer.color = Color.Lerp(initialColor, finalColor, curve.Evaluate(normalizedTime));
        currentTime += Time.deltaTime;         



        if (Input.GetKeyDown(KeyCode.Space)) StartTween();
    }
    private void StartTween()
    {
        currentTime = 0f;
        spriteRenderer.color = initialColor;
        initialPosition = transform.position;
        finalPosition = targetTransform.position;
    }
    private float EaseInQuad(float x)
    {
        return x * x;
    }
}
