using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHolder : MonoBehaviour
{
    public bool isFill = true;

    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 targetPoint;
    private Vector3 currentPoint;

    public GameObject circle;
    public GameObject startCircle;
    public GameObject endCircle;
    public SpriteRenderer capsuleButton;

    public Color startColor;
    public Color endColor;
    private Color targetColor;
    private Color currentColor;

    private float startTime;
    public float duration = 0.1f;
    private float currentProgress;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = startCircle.transform.localPosition;
        endPoint = endCircle.transform.localPosition;

        currentPoint = startPoint;
        targetPoint = startPoint;

        currentColor = startColor;
        targetColor = startColor;

        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentProgress = (Time.time - startTime)/duration;
        currentProgress = Mathf.Clamp(currentProgress, 0, 1);
        circle.transform.localPosition = Vector3.Lerp(currentPoint, targetPoint, currentProgress);
        capsuleButton.color = Color.Lerp(currentColor, targetColor, currentProgress);
    }

    void OnMouseUp() {
        startTime = Time.time;

        if (isFill) {
            targetPoint = endPoint;
            currentPoint = startPoint;

            targetColor = endColor;
            currentColor = startColor;
        } else {
            targetPoint = startPoint;
            currentPoint = endPoint;

            targetColor = startColor;
            currentColor = endColor;
        }
        isFill = !isFill;
    }
}
