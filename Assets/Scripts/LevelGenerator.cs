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
    public Text scoreText;

    private int playerScore = 0;
    private List<Color> colorList = new List<Color>();

    // Start is called before the first frame update
    void Start()
    {
        colorList.Add(new Color(1f, 0f, 0f, 1f));
        colorList.Add(new Color(0f, 1f, 0f, 1f));
        colorList.Add(new Color(0f, 0f, 1f, 1f));

        StartCoroutine("CreateMorePipes");    
    }

    IEnumerator CreateMorePipes()
    {
        while(true)
        {
            int num = Random.Range(3, 9);

            pipePrefab.gameObject.transform.localScale = new Vector3(1, 0, 1);
            pipePrefab.gameObject.transform.localScale += new Vector3(0, 10, 0);
            GameObject topPipe = (GameObject)Instantiate(
                pipePrefab,
                new Vector3(player.transform.position.x + 8, num, 1),
                Quaternion.identity);

            topPipe
                .GetComponentInChildren<SpriteRenderer>()
                .color = colorList[Random.Range(0, colorList.Count)];

            GameObject bottomPipe = (GameObject)Instantiate(
                pipePrefab,
                new Vector3(player.transform.position.x + 8, num-13, 1),
                Quaternion.identity);

            bottomPipe
                .GetComponentInChildren<SpriteRenderer>()
                .color = colorList[Random.Range(0, colorList.Count)];

            // if you pass a pipe then add one to your score.
            if (player.transform.position.x > pipePrefab.transform.position.x){
                playerScore += 1;
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
