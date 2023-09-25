using UnityEngine;

public class Random : MonoBehaviour {
        public int depth = 20;
        public int width = 256;
        public int height = 256;
        public float scale = 20f;
        public Terrain terrain;
        void Start()
        {
            terrain.terrainData = GenerateTerrain(terrain.terrainData);
        }

        TerrainData GenerateTerrain(TerrainData terrainData)
        {
            terrainData.heightmapResolution = width + 1;

            terrainData.size = new Vector3(width, depth, height);

            terrainData.SetHeights(0, 0, GenerateHeights());

            return terrainData;
        }

        float[,] GenerateHeights()
        {
            float[,] heights = new float[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    heights[x, y] = CalculateHeight(x, y);
                }
            }

            return heights;
        }

        float CalculateHeight(int x, int y)
        {
            float xCoord = x / width * scale;
            float yCoord = y / height * scale;
            //Debug.Log(Mathf.PerlinNoise(xCoord, yCoord));
            return Mathf.PerlinNoise(xCoord, yCoord);
        }
}

