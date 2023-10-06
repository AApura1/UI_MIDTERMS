using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Button_Manager : MonoBehaviour
{
    public Image Marcy;
    public RectTransform Image;
    public float transitionDuration = 1.0f;
    public float slideDistance = -400.0f;
    public float swingAngle = 100.0f;
    public float flyDistance = 500.0f;
    private bool isZoomOut = false;
    private bool isFadedOut = true;
    private bool isSlidingOut = true;
    private bool isSwingingOut = true;
    private bool isFlyingOut = true;
    private bool isFlippedOut = true;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        initialPosition = Image.anchoredPosition;
        initialRotation = Image.rotation;
    }


    public void Zoom()
    {
        float zoomVal = 0;
        float targetScale = isZoomOut ? 1.0f : zoomVal;
        Marcy.transform.DOScale(targetScale, 0.25f);
        isZoomOut = !isZoomOut;
    }

    public void Fade()
    {
        if (isFadedOut)
            {
               Marcy.DOFade(1.0f, transitionDuration);
             }
        else
            {
               Marcy.DOFade(0.0f, transitionDuration);
            }
        isFadedOut = !isFadedOut;
    }

    public void Slide()
    {
        if (isSlidingOut)
        {
            Image.DOAnchorPosX(initialPosition.x, transitionDuration);
        }
        else
        {
            Image.DOAnchorPosX(-slideDistance, transitionDuration);
        }

        isSlidingOut = !isSlidingOut;
    }
    public void Swing()
    {
        if (isSwingingOut)
        {
            Image.DORotateQuaternion(initialRotation, transitionDuration);
        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, isSwingingOut ? swingAngle : swingAngle);
            Image.DORotateQuaternion(targetRotation, transitionDuration);
        }

        isSwingingOut = !isSwingingOut;
    }
    public void Fly()
    {
        if (isFlyingOut)
        {
            Image.DOAnchorPosY(initialPosition.y, transitionDuration);
        }
        else
        {
            Image.DOAnchorPosY(-flyDistance, transitionDuration);
        }

        isFlyingOut = !isFlyingOut;
    }
    public void Flip()
    {
        if (isFlippedOut)
        {
            Image.DOScale(new Vector3(1, 1, 1), transitionDuration);
        }
        else
        {
            Image.DOScale(new Vector3(0, 1, 1), transitionDuration);
        }

        isFlippedOut = !isFlippedOut;
    }
}