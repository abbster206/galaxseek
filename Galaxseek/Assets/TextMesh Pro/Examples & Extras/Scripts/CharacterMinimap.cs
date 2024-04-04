using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMinimap : MonoBehaviour
{
    public float scale;
    //public Color color = new Color(1f, 0f, 0f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        Minimap.Instance.RegisterEnemy(this);
    }
}
