using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Health : MonoBehaviour
{
    public float health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite halfHeart;

    void Update()
    {
        setHeartSprites();
        setEnabledHearts();
    }

    private void setHeartSprites()
    {
        int iHeart = setFullSprites();
        iHeart = setHalfSprite(iHeart);
        setEmptySprites(iHeart);
    }

    private int setFullSprites()
    {
        int iHeart = 0;
        for (; iHeart + 1 <= new float[] { hearts.Length, numOfHearts, health }.Min(); iHeart++)
        {
            hearts[iHeart].sprite = fullHeart;
        }
        return iHeart;
    }

    private int setHalfSprite(int iHeart)
    {
        if (health % 1 != 0)
        {
            hearts[iHeart].sprite = halfHeart;
            iHeart++;
        }
        return iHeart;
    }

    private int setEmptySprites(int iHeart)
    {
        for (; iHeart + 1 < new float[] { hearts.Length - 1, numOfHearts }.Min(); iHeart++)
        {
            hearts[iHeart].sprite = emptyHeart;
        }
    }

    private void setEnabledHearts()
    {
        for (int iHeart = 0; iHeart < hearts.Length; iHeart++)
        {
            if (iHeart < numOfHearts)
            {
                hearts[iHeart].enabled = true;
            }
            else
            {
                hearts[iHeart].enabled = false;
            }
        }
    }

}
