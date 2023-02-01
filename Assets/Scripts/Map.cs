using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Map : MonoBehaviour
{
   public TileBlock[] tileBlocks;
   private int[,] _groundBlocks;
   private int?[,] _blocks;
   public int mapSizeX;
   public int mapSizeZ;


   private void Awake()
   {
      mapSizeX = 21;
      mapSizeZ = 21;
   }

   private void Start()
   {
      GenerateVisualMap();
      GenerateMap();
   }
   
   void GenerateVisualMap()
   {
      //Zeminin belirlenmesi
      _groundBlocks = new int[mapSizeX,mapSizeZ];
      _blocks = new int?[mapSizeX,mapSizeZ];

      for (int x = 0; x < mapSizeX; x++)
      {
         for (int z = 0; z < mapSizeZ; z++)
         {
            _groundBlocks[x, z] = 0;
         }
      }

     for (int x = 1; x < mapSizeX-1; x+=2) // Kirilamaz duvarlar
     {
        for (int z = 1; z < mapSizeZ-1; z+=2)
        {
            _blocks[x, z] = 1;
        }
     }

     int temp;
     for (int x = 0; x < mapSizeX; x++)
     {
        for (int z = 0; z < mapSizeZ; z++)
        {
           temp = UnityEngine.Random.Range(0, 4);
           if (_blocks[x,z] == null) // Eger kirilabilir duavarlarin gelecegi yerler bos ise
           {
              
              if (temp>1)
              {
                 _blocks[x, z] = 2;
              }
              else
              {
                 continue;
              }
           }
           else
           {
              continue;
           }
        }
     }
     
     //Yardirma yontemi ile karakterlerin spawnpointlerinin gelecegi yerlerin bosaltilmasi
     _blocks[1,20] = null;
     _blocks[0,20] = null;
     _blocks[0,19] = null;
     _blocks[0,1] = null;
     _blocks[0,0] = null;
     _blocks[1,0] = null;
     _blocks[19,0] = null;
     _blocks[20,0] = null;
     _blocks[20,1] = null;
     _blocks[20,19] = null;
     _blocks[20,20] = null;
     _blocks[19,20] = null;

    
   }
   
   void GenerateMap()
   {
      //Yeri oluşturma
      for (int x = 0; x < mapSizeX; x++)
      {
         for (int z = 0; z < mapSizeZ; z++)
         {
            TileBlock tb = tileBlocks[_groundBlocks[x,z]];
            GameObject go = Instantiate(tb.blockPrefab, new Vector3(x, 0, z), Quaternion.identity);
            go.transform.parent = gameObject.transform;
         }
      }


      //Kırılmaz ve kırılabilir duvar oluşturma
      for (int x = 0; x < mapSizeX; x++)
      {
         for (int z = 0; z < mapSizeZ; z++)
         {
            if (_blocks[x,z].HasValue)
            {
               TileBlock tb = tileBlocks[(int)_blocks.GetValue(x,z)];
               GameObject go = Instantiate(tb.blockPrefab, new Vector3(x, 1, z), Quaternion.identity);
               go.transform.parent = gameObject.transform;
            }
            else
            {
               continue;
            }
         }
      }

      
      //Kenar duvarlarini olusturma
      for (int x = -1; x < mapSizeX+1; x++)
      {
         for (int z = -1; z < mapSizeZ+1; z++)
         {
            if (x == -1 || z == -1 || x == mapSizeX || z == mapSizeZ)
            {
               TileBlock tb = tileBlocks[3];
               GameObject go = Instantiate(tb.blockPrefab, new Vector3(x, 0, z), Quaternion.identity);
               go.transform.parent = gameObject.transform;
               GameObject obj = Instantiate(tb.blockPrefab, new Vector3(x, 1, z), Quaternion.identity);
               obj.transform.parent = gameObject.transform;
            }
         }
      }
    
   }

  
}
