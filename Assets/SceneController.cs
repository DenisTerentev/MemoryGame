using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private MemoryCard startCard;
    [SerializeField] private Sprite[] images;
    [SerializeField] private TextMesh textLabel;
    private int gridRows = 2;
    private int gridCols = 4;
    private float _distX = 2f;
    private float _distY = 2.5f;

    private MemoryCard _firstCard;
    private MemoryCard _secondCard;
    private int _score = 0;
    public bool IsOpen
    {
        get { return _secondCard != null; }
    }

    void Start()
    {
        int[] masID = { 0, 0, 1, 1, 2, 2, 3, 3 };
        Stack<int> stackID = ShuffleArray(masID);
        
        Vector3 startPos = startCard.transform.position;
        for(int i=0;i<gridRows;i++)
        {
            for(int j=0;j<gridCols;j++)
            {
                MemoryCard card;
                if (i == 0 && j == 0) card = startCard;
                else
                {
                    card = Instantiate(startCard) as MemoryCard;
                }
                float posX = _distX * j+startPos.x;
                float posY = startPos.y-(_distY*i);
                card.SetCard(stackID.Peek(), images[stackID.Peek()]);
                stackID.Pop();
                card.transform.position=new Vector3(posX,posY,startPos.z);
                
            }
        }
    }
    private Stack<int> ShuffleArray(int[] masID)
    {
        Stack<int> newStack = new Stack<int>();
        for(int i=0;i<masID.Length;i++)
        {
            int r = Random.Range(0, masID.Length);
            int buf = masID[r];
            masID[r] = masID[i];
            masID[i] = buf;

        }
        for (int i=0;i<masID.Length;i++)
        {
            newStack.Push(masID[i]);
        }
        return newStack;
    }
    public void CardRevaled(MemoryCard card)
    {
        if (_firstCard == null) _firstCard = card;
        else
        {
            _secondCard = card;
            StartCoroutine(CheckMatch());
        }
    }
    private IEnumerator CheckMatch()
    {
        if(_firstCard.ID==_secondCard.ID)
        {
            _score++;
            textLabel.text = "Score: " + _score;
        }
        else
        {
            yield return new WaitForSeconds(.5f);
            _firstCard.CloseCard();
            _secondCard.CloseCard();
            _score--;
            textLabel.text = "Score: " + _score;
        }
        _firstCard = null;
        _secondCard = null;
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
