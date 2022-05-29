using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject ground;
    public GameObject ceiling;
    public GameObject player;
    public GameObject collectable;
    public Text scoreText;

    private int playerScore = 0;
    private List<Color> colorList = new List<Color>();

    // Start is called before the first frame update
    void Start()
    {
        colorList.Add(new Color(1f, 0f, 0f, 1f));
        colorList.Add(new Color(0f, 1f, 0f, 1f));
        colorList.Add(new Color(0f, 0f, 1f, 1f));

        StartCoroutine(CreateMorePipes());    
    }

    IEnumerator CreateMorePipes()
    {
        while(true)
        {
            int num = Random.Range(3, 9);

            // Initializing the pipe scale
            pipePrefab.gameObject.transform.localScale = new Vector3(1, 0, 1);
            pipePrefab.gameObject.transform.localScale += new Vector3(0, 10, 0); // TODO: Why not have 1, 10, 1 on the line above?

            // Create the top pipe 10 units in front of the player's X and at a random bounded height.
            GameObject topPipe = Instantiate(
                pipePrefab,
                new Vector3(player.transform.position.x + 10, num, 1),
                Quaternion.identity);

            // Set the color to a random one in the color list.
            topPipe
                .GetComponentInChildren<SpriteRenderer>()
                .color = colorList[Random.Range(0, colorList.Count)];

            // Create the bottom pipe 10 units in front of the player's X and at the same height as the top pipe - 13 so there is a 3 unit gap between the two pipes.
            GameObject bottomPipe = (GameObject)Instantiate(
                pipePrefab,
                new Vector3(player.transform.position.x + 10, num-13, 1),
                Quaternion.identity);

            // Set the color of the bottom pipe.
            bottomPipe
                .GetComponentInChildren<SpriteRenderer>()
                .color = colorList[Random.Range(0, colorList.Count)];

            // if you pass a pipe then add one to your score.
            if (player.transform.position.x > pipePrefab.transform.position.x){
                playerScore++;
            }

            // Create a coin/collectable every other pipe spawn
            if (playerScore % 2 == 0)
            {
                // spawn a collectable.
                GameObject c = Instantiate(
                    collectable,
                    new Vector3(player.transform.position.x + 12, player.transform.position.y, 1),
                    Quaternion.identity);
            }

            // set the score text
            scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score : " + playerScore.ToString();

            yield return new WaitForSeconds(2);
            StartCoroutine(DestroyPipe(topPipe, bottomPipe));
        }
    }

    IEnumerator DestroyPipe(GameObject top, GameObject bottom)
    {
        yield return new WaitForSeconds(8);
        Destroy(top);
        Destroy(bottom);
    }

    // Update is called once per frame
    void Update()
    {
        ground.transform.position = new Vector3(player.transform.position.x, -5, 0);
        ceiling.transform.position = new Vector3(player.transform.position.x, 5, 0);
    }
}
