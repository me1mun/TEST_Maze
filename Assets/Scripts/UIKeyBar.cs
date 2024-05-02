using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKeyBar : MonoBehaviour
{
    [SerializeField] private GameObject keyIconPrefab;
    [SerializeField] private Transform keyLayout;

    public List<Image> keyIcons = new List<Image>();

    public void InitializeKeys(int totalKeys)
    {
        for (int i = 0; i < totalKeys; i++)
        {
            GameObject keyIconObj = Instantiate(keyIconPrefab, keyLayout);
            Image keyIcon = keyIconObj.GetComponent<Image>();
            keyIcons.Add(keyIcon);
        }

        UpdateKeyIcons(0);
    }

    public void UpdateKeyIcons(int collectedKeys)
    {
        for (int i = 0; i < keyIcons.Count; i++)
        {
            keyIcons[i].color = (i < collectedKeys) ? Color.white : Color.black;
        }
    }
}
