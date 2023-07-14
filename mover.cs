
using UnityEngine;

public class mover : MonoBehaviour
{    [Range(-1f,1f)]
    public float scrollspeed = 0.5f;
    private float offset;
    private Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime* scrollspeed) / 10f;
        mat.SetTextureOffset("main",new Vector2 (offset,0));
    }
}
