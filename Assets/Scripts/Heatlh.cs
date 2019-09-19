using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heatlh : MonoBehaviour
{
    public float health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite halfHeart;

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Displaying the hearts for the corresponding health
            if (i < health)
            {
                hearts[i].sprite = fullHeart;

                // For displaying half hearts. (if someone can make the logic more cleaner would love it. But since we will
                // be adding enemy damage it might change.)
                if ((health % 0.5) == 0)
                {
                    if (health != 5)
                    {
                        for (int j = 0; j <= (health - 0.5); j++)
                        {
                            if (j == i)
                            {
                                hearts[j].sprite = halfHeart;
                            }
                            else
                            {
                                hearts[j].sprite = fullHeart;
                            }

                        }
                    }
                    
                }
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            // Chnaging total number of hearts/heatlh
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }else
            {
                hearts[i].enabled = false;
            }

        }
    }

}
