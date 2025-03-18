using UnityEngine;



public class ParlaxLayer : MonoBehaviour
{
    public float rate =1.0f;  // Array to hold different rates for each tile.
    public Transform[] tiles;
    public float left = -19f;
    public Vector3 right = new Vector3(19f, 0f, 0f);
    public Parallax.layer layer;
    public static class Parallax
    {
        public static float speed = 2f;
        public enum layer
        { 
        Foreground,Midground,Background
        }
        public static float GetSpeed(layer layer)
        {
            switch (layer)
            {
                case layer.Foreground:
                    return speed * 1;
                    case layer.Midground:
                    return speed * 0.5f;
                    case layer .Background:
                    return speed * 0.1f;
                    default:
                    return speed * 1;


            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            // Use the corresponding rate for each tile
            tiles[i].position += Vector3.left * Time.deltaTime * rate * Parallax.GetSpeed(layer );

            // Reset position when tile moves past left boundary
            if (tiles[i].position.x <= left)
            {
                tiles[i].position = right;
            }
        }
    }
}
