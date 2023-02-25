using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private List<SpriteRenderer> creatures = new List<SpriteRenderer>();

    private int numCreatures;

    public SpriteRenderer elephantPrefab;
    public SpriteRenderer kangarooPrefab;
    public SpriteRenderer octopusPrefab;
    public SpriteRenderer snailPrefab;
    public SpriteRenderer turtlePrefab;

    private Vector3 minPosition;
    private Vector3 maxPosition;
    private float stdDevX;
    private float stdDevY;

    // Start is called before the first frame update
    void Start()
    {
        minPosition = Camera.main.ScreenToWorldPoint(Vector3.zero);
        maxPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        stdDevX = maxPosition.x / 4;
        stdDevY = maxPosition.y / 4;

        // Spawn in the first wave of creatures
        Spawn();
    }

    /// <summary>
    /// Generate a new wave of creatures, placed randomly throughout the world
    /// </summary>
    public void Spawn()
    {
        // Make sure our screen is clear before we spawn any new creatures
        CleanUp();

        // Create a random number of creatures in the world
        numCreatures = Random.Range(1, 100);
        for (int i = 0; i < numCreatures; i++)
        {
            // Place a random creature at a random position and add that creature to the creatures list
            creatures.Add(SpawnCreature());
        }

    }

    /// <summary>
    /// Picks a random creature from the prefabs that we have
    /// </summary>
    /// <returns>The random prefab</returns>
    private SpriteRenderer ChooseRandomCreature()
    {
        // generate result
        int chance = Random.Range(1, 100);

        // elephant: 25%
        if (chance <= 25) return elephantPrefab;

        // turtle: 20%
        else if (chance <= 45) return turtlePrefab;

        // snail: 15%
        else if (chance <= 60) return snailPrefab;

        // octopus: 10%
        else if (chance <= 70) return octopusPrefab;
        
        // kangaroo: 30%
        return kangarooPrefab;

    }

    /// <summary>
    /// Spawns an individual creature at a random location in the world
    /// </summary>
    /// <returns>The spawned Creature</returns>
    private SpriteRenderer SpawnCreature()
    {
        Vector3 spawnPosition = new Vector3(
            Gaussian(0f, stdDevX), 
            Gaussian(0f, stdDevY),
            0f);
        SpriteRenderer spawnedCreature = Instantiate(ChooseRandomCreature(), spawnPosition, Quaternion.identity);
        spawnedCreature.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
        return spawnedCreature;
    }
    
    private void CleanUp()
    {
        foreach (SpriteRenderer creature in creatures)
        {
            Destroy(creature.gameObject);
        }
        creatures.Clear();
    }

    private float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue =
            Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
            Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;
    }
}
