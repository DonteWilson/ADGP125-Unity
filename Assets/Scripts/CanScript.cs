using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using ADGP125;

public class CanScript : MonoBehaviour {
    //Refers to Image Script and grabs images.
    Images Image;

    //Creates
    public List<Unit> BattleGroup;

    public Canvas SetPartiesCanvas;

    public Canvas MainCanvas;

    public Canvas ArenaCanvas;
    //public button for play
    public Button Play;
    //Player 1 Image
    public RawImage Plyr1;
    //Player 1 name
    public InputField P1name;
    //Player 1 hp
    public InputField P1hp;
    //Player 1 damage
    public InputField P1dmg;
    //Player 1 Armor
    public InputField P1armor;
    //Player 1 Speed
    public InputField P1Spd;
    //Player 1 Level
    public InputField P1lvl;

    //Player 2 Image
    public RawImage Plyr2;
    //Player 2 name
    public InputField P2name;
    //Player 2 hp
    public InputField P2hp;
    //Player 2 damage
    public InputField P2dmg;
    //Player 2 Armor
    public InputField P2armor;
    //Player 2 Speed
    public InputField P2Spd;
    //Player 2 Level
    public InputField P2lvl;

    //Player 3 Image
    public RawImage Plyr3;
    //Player 3 name
    public InputField P3name;
    //Player 3 hp
    public InputField P3hp;
    //Player 3 dmg
    public InputField P3dmg;
    //Player 3 armor
    public InputField P3armor;
    //Player 3 speed
    public InputField P3Spd;
    //Player 3 Level
    public InputField P3lvl;

    public Text Player1N;

    public Text Player2N;

    public Text Player3N;

    public Text Enemy1N;

    public Text Enemy2N;

    public Text Enemy3N;

    public RawImage P1;

    public RawImage P2;

    public RawImage P3;

    

   



    public void Start()
    {
        BattleGroup = new List<Unit>();

        Image = GetComponent<Images>();

        Play.enabled = false;

        MainCanvas.enabled = true;

        SetPartiesCanvas.enabled = false;

        ArenaCanvas.enabled = false;

    }
    public void NewGame()
    {
        Play.enabled = false;

        P1name.text = "";

        Player1N.text = "";

        P1hp.text = "";

        P1dmg.text = "";

        P1armor.text = "";

        P1Spd.text = "";

        P1lvl.text = "";


        P2name.text = "";

        Player2N.text = "";

        P2hp.text = "";

        P2dmg.text = "";

        P2armor.text = "";

        P2Spd.text = "";

        P2lvl.text = "";

        P3name.text = "";

        Player3N.text = "";

        P3hp.text = "";

        P3dmg.text = "";

        P3armor.text = "";

        P3Spd.text = "";

        P3lvl.text = "";

        SetPartiesCanvas.enabled = true;

    }
    private void SetParties(List<Unit> p, List<Unit> e)
    {
        if (BattleGroup.Count >= 1)
        {
            BattleGroup.RemoveRange(0, BattleGroup.Count);
        }
        //creates a random class out of 3 possibilities
        System.Random r = new System.Random();

        //Calls the next function to grab a random group of 3 members
        int p1 = r.Next(0, p.Count - 1);
        int p2 = r.Next(0, p.Count - 1);
        int p3 = r.Next(0, p.Count - 1);
        //goes through different players
        while (p1 == p2)
        {
            p2 = r.Next(0, p.Count - 1);
        }
        //goes through different players
        while (p1 == p3)
        {
            p3 = r.Next(0, p.Count - 1);
        }

        if (p1 != p2 && p1 != p3)
        {
            P1name.text = p[p1].Name;
            Player1N.text = p[p1].Name;
            P1hp.text = p[p1].HP.ToString();
            P1dmg.text = p[p1].HP.ToString();
            P1armor.text = p[p1].Armor.ToString();
            P1lvl.text = p[p1].Lvl.ToString();
            BattleGroup.Add(p[p1]);
        }

        while (p2 == p1)
        {
            p2 = r.Next(0, p.Count - 1);
        }

        while (p2 == p3)
        {
            p3 = r.Next(0, p.Count - 1);
        }

        if (p2 != p3 && p2 != p1)
        {
            P2name.text = p[p2].Name;
            Player2N.text = p[p2].Name;
            P2hp.text = p[p2].HP.ToString();
            P2dmg.text = p[p2].Dmg.ToString();
            P2armor.text = p[p2].Armor.ToString();
            P2lvl.text = p[p2].Lvl.ToString();
            BattleGroup.Add(p[p2]);
        }

        while (p3 == p1)
        {
            p3 = r.Next(0, p.Count - 1);

            while (p3 == p2)
            {
                p3 = r.Next(0, p.Count - 1);
            }
        }

        if (p3 != p2 && p3 != p1)
        {
            P3name.text = p[p3].Name;
            Player3N.text = p[p3].Name;
            P3hp.text = p[p3].HP.ToString();
            P3dmg.text = p[p3].Dmg.ToString();
            P3armor.text = p[p3].Armor.ToString();
            P3lvl.text = p[p3].Lvl.ToString();
            BattleGroup.Add(p[p3]);

        }
        CharIcon(BattleGroup);

        System.Random a = new System.Random();

        int e1 = a.Next(0, e.Count);
        int e2 = a.Next(0, e.Count);
        int e3 = a.Next(0, e.Count);

        while (e1 == e2)
        {
            e2 = a.Next(0, e.Count - 1);
        }
        while (e2 == e3)
        {
            e3 = a.Next(0, e.Count - 1);
        }
        while (e3 == e1)
        {
            e1 = a.Next(0, e.Count - 1);

            while (e1 == e2)
            {
                e1 = a.Next(0, e.Count - 1);
            }
        }

        BattleGroup.Add(e[e1]);
        BattleGroup.Add(e[e2]);
        BattleGroup.Add(e[e3]);

      

    }
    private void PlayerObjects()
    {
        Play.enabled = true;

        List<Unit> pObjects = new List<Unit>();

        List<Unit> players = new List<Unit>();

        List<Unit> enemies = new List<Unit>();

        Unit Jittery = new Unit("Jittery", 100, 10, 15, 5, 0, "Player");
        Unit Ryyul = new Unit("Ryyul", 100, 9, 10, 4, 0, "Player");
        Unit Sneaky = new Unit("Sneaky", 100, 9, 10, 5, 0, "Player");
        Unit Rory = new Unit("Rory", 100, 8, 10, 5, 0, "Player");
        Unit Yato = new Unit("Yato", 100, 10, 10, 5, 0, "Player");
        Unit Meteos = new Unit("Meteos", 100, 9, 10, 4, 0, "Player");


        Unit Savor = new Unit("Savor", 100, 5, 5, 4, 50, "Enemy");
        Unit Friv = new Unit("Friv", 99, 6, 10, 4, 50, "Enemy");
        Unit Atoli = new Unit("Atoli", 100, 7, 6, 4, 50, "Enemy");
        Unit Violet = new Unit("Violet", 98, 5, 5, 5, 100, "Enemy");
        Unit Muur = new Unit("Savor", 100, 5, 6, 4, 50, "Enemy");
        Unit Loki = new Unit("Friv", 99, 6, 4, 4, 25, "Enemy");

        //Adds Player Unit Objects
        pObjects.Add(Jittery);
        pObjects.Add(Ryyul);
        pObjects.Add(Sneaky);
        pObjects.Add(Rory);
        pObjects.Add(Yato);
        pObjects.Add(Meteos);

        //Adds Enemy Unit Objects
        pObjects.Add(Savor);
        pObjects.Add(Friv);
        pObjects.Add(Atoli);
        pObjects.Add(Violet);
        pObjects.Add(Muur);
        pObjects.Add(Loki);

        foreach (Unit i in pObjects)
        {
            if(i.Type == "Player")
            {
                players.Add(i);
            }
            if(i.Type == "Enemy")
            {
                enemies.Add(i);
            }
        }
        SetParties(players, enemies);

    }
    public void CharIcon(List<Unit> units)
    {
        for(int i = 0; i < units.Count; i++)
        {
            if(units[i].Name == P1name.text)
            {
                switch (units[i].Name)
                {
                    case "Jittery":
                        P1.texture = Image.Jittery;
                        Plyr1.texture = Image.Jittery;
                        break;
                    case "Ryyul":
                        P1.texture = Image.Ryyul;
                        Plyr1.texture = Image.Ryyul;
                        break;
                    case "Meteos":
                        P1.texture = Image.Meteos;
                        Plyr1.texture = Image.Meteos;
                        break;
                    case "Sneaky":
                        P1.texture = Image.Sneaky;
                        Plyr1.texture = Image.Sneaky;
                        break;
                    case "Yato":
                        P1.texture = Image.Yato;
                        Plyr1.texture = Image.Yato;
                        break;
                    case "Rory":
                        P1.texture = Image.Rory;
                        Plyr1.texture = Image.Rory;
                        break;
                    default:
                        break;
                }
            }
        }
    }


}
