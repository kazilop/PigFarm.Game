using UnityEngine;

public class GameManager : MonoBehaviour
{
    public StoneScript rockPrefab;
    public Transform parent;

    private int rockX = 8;
    private int rockY = 4;

    void Start()
    {
        SetRock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetRock()
    {
        float ofsetX = -8.4f;
        float ofsetY = -3.4f;

        float multX = 2.2f;
        float multY = 2;

        

        for (int yy = 0; yy < rockY; yy++)
        {
            for (int xx = 0; xx < rockX; xx++)
            {
                Vector3 pos = new Vector3(xx * multX + ofsetX, yy * multY + ofsetY, 0f);
                var s = Instantiate(rockPrefab, pos, Quaternion.identity,parent);
                s.name = "Stone " + xx + ":" + yy;
            }

            ofsetX = ofsetX + 0.3f;
        }
    }
}
