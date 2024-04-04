using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    public static Minimap Instance {  get; private set; }
    [SerializeField] Transform playerOnScene;
    [SerializeField] RectTransform playerOnMap;
    [SerializeField] float scale = 1f;
    private List<Transform> enemies = new List<Transform>();
    private List<RectTransform> enemiesOnMap = new List<RectTransform>();
       

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            AlignPosition(i);
        }
    }
    public void RegisterEnemy (CharacterMinimap enemy)
    {
        enemies.Add(enemy.transform);
        GameObject temp = Instantiate(playerOnMap.gameObject, playerOnMap);
      //  temp.GetComponent<Image>().color = enemy.color;
        temp.transform.localScale = Vector3.one * enemy.scale;
        enemiesOnMap.Add(temp.GetComponent<RectTransform>());
    }

    void AlignPosition(int i)
    {
        var enemy = enemies[i];
        var indicator = enemiesOnMap[i];

        if (enemy != null && indicator != null)
        {
            Vector3 relativePos;

            relativePos = enemy.position - playerOnMap.position;

            indicator.anchoredPosition = new Vector2(relativePos.x, relativePos.z) * scale;
        }
    }
}
// https://youtu.be/VLpqWWiqKq8?t=753
