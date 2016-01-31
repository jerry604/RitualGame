using UnityEngine;
using System.Collections;

public class WatcherScript : MonoBehaviour {
    public WizardController target;
    public GameObject chalkStar;
    public GameObject coin;
    public GameObject skull;
    public GameObject sacredVestments;

	private string state = "init";
	public string itemNeeded = "";
	public Sprite bgChalk;
	public Sprite candlePlaced;
	public Sprite iconNeedChalk;
	public Sprite iconNeedCandle;
	public Sprite iconNeedCoin;
	public Sprite iconNeedBikini;
	public Sprite iconNeedSkull;
	public Sprite iconNeedMagic;
    // Use this for initialization
    void Start () {
        //SpriteRenderer bgsr = bg.GetComponent<SpriteRenderer>();
        //bgsr.sprite = Sprite.Create()
    }
	
	// Update is called once per frame
	void Update () {

        if (isClose())
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            if (Input.GetButtonDown("Interact"))
            {
				if( state == "init" )
				{
					GameObject.Find("background").GetComponent<SpriteRenderer>().sprite = bgChalk;
					//bg.transform.position = new Vector3(bg.transform.position.x, bg.transform.position.y, 4);
					//bgChalk.transform.position = new Vector3(bgChalk.transform.position.x, bgChalk.transform.position.y, 1);
					state = "needChalk";
					itemNeeded = "Chalk";
					GameObject.Find("HelpfulIcon").GetComponent<SpriteRenderer>().sprite = iconNeedChalk;
				} else if ( state == "needChalk" && target.getTagName() == "Chalk" )
				{
					chalkStar.transform.position = new Vector3(chalkStar.transform.position.x, chalkStar.transform.position.y, 0);
					state = "needCandle";
					itemNeeded = "Candle";
					GameObject.Find("HelpfulIcon").GetComponent<SpriteRenderer>().sprite = iconNeedCandle;
					target.removeTagName();
				}
				else if (state == "needCandle" && target.getTagName() == "Candle" )
				{
					GameObject.Find("candle1").GetComponent<SpriteRenderer>().sprite = candlePlaced;
					state = "placeCandle2";
				}
				else if (state == "placeCandle2")
				{
					GameObject.Find("candle2").GetComponent<SpriteRenderer>().sprite = candlePlaced;
					state = "placeCandle3";
				}
				else if (state == "placeCandle3")
				{
					GameObject.Find("candle3").GetComponent<SpriteRenderer>().sprite = candlePlaced;
					state = "placeCandle4";
				}
				else if (state == "placeCandle4")
				{
					GameObject.Find("candle4").GetComponent<SpriteRenderer>().sprite = candlePlaced;
					state = "placeCandle5";
				}
				else if (state == "placeCandle5")
				{
					GameObject.Find("candle5").GetComponent<SpriteRenderer>().sprite = candlePlaced;
					state = "needCoin";
					itemNeeded = "Coin";
					GameObject.Find("HelpfulIcon").GetComponent<SpriteRenderer>().sprite = iconNeedCoin;
					target.removeTagName();
				}
				else if (state == "needCoin" && target.getTagName() == "Coin" )
				{
					coin.transform.position = new Vector3(coin.transform.position.x, coin.transform.position.y, -1);
					state = "needSkull";
					itemNeeded = "Skull";
					GameObject.Find("HelpfulIcon").GetComponent<SpriteRenderer>().sprite = iconNeedSkull;
					target.removeTagName();
				}
				else if (state == "needSkull" && target.getTagName() == "Skull" )
				{
					skull.transform.position = new Vector3(skull.transform.position.x, skull.transform.position.y, -1);
					state = "needSacredVestments";
					itemNeeded = "Bikini";
					GameObject.Find("HelpfulIcon").GetComponent<SpriteRenderer>().sprite = iconNeedBikini;
					target.removeTagName();
				}
				else if (state == "needSacredVestments" && target.getTagName() == "Bikini")
				{
					sacredVestments.transform.position = new Vector3(sacredVestments.transform.position.x, sacredVestments.transform.position.y, -1);
					state = "lightCandle1";
					GameObject.Find("HelpfulIcon").GetComponent<SpriteRenderer>().sprite = iconNeedMagic;
					target.removeTagName();
				}
				else if (state == "lightCandle1")
				{
					GameObject.Find("candle1").GetComponent<SpriteRenderer>().sprite = null;
					GameObject.Find("candle1").GetComponent<Animator>().enabled = true;
					state = "lightCandle2";
				}
				else if (state == "lightCandle2")
				{
					GameObject.Find("candle2").GetComponent<SpriteRenderer>().sprite = null;
					GameObject.Find("candle2").GetComponent<Animator>().enabled = true;
					state = "lightCandle3";
				}
				else if (state == "lightCandle3")
				{
					GameObject.Find("candle3").GetComponent<SpriteRenderer>().sprite = null;
					GameObject.Find("candle3").GetComponent<Animator>().enabled = true;
					state = "lightCandle4";
				}
				else if (state == "lightCandle4")
				{
					GameObject.Find("candle4").GetComponent<SpriteRenderer>().sprite = null;
					GameObject.Find("candle4").GetComponent<Animator>().enabled = true;
					state = "lightCandle5";
				}
				else if (state == "lightCandle5")
				{
					GameObject.Find("candle5").GetComponent<SpriteRenderer>().sprite = null;
					GameObject.Find("candle5").GetComponent<Animator>().enabled = true;
					state = "summonMagic!";
				}
				else if (state == "summonMagic!")
				{

					chalkStar.GetComponent<SpriteRenderer>().sprite = null;
					chalkStar.GetComponent<Animator>().enabled = true;
					GameObject.Find("HelpfulIcon").GetComponent<SpriteRenderer>().sprite = null;
					state = "end?";
				}

			}
		} else
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, 2);
		}
	}

    bool isClose()
    {
        if( ( Mathf.Abs( target.wizardX - transform.position.x ) < 10 ) && ( Mathf.Abs( target.wizardY - transform.position.y ) < 3 ) ) {
            return true;
        } else
        {
            return false;
        }
    }
}
